using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weather.Models.Abstract;
using weather.Models.Repositorys;
using weather.Models.Webservices;

namespace weather.Models
{
    public class WeatherService : WeatherServiceBase
    {
        private IWeatherRepository _repository;

        public WeatherService()
            :this(new WeatherRepository())
        {
            // Empty
        }

        public WeatherService(IWeatherRepository repository)
        {
            _repository = repository;
        }

        public override IEnumerable<Geoinfo> GetGeoinfos(string city)
        {
            var geoinfo = _repository.GetGeoinfoByCity(city);

            if (!geoinfo.Any())
            {
                // Hämta data från webservice
                var geonameWebservice = new GeonameWebservice();
                geoinfo = geonameWebservice.GetGeoinfo(city);

                // Lägg in data i db
                foreach (var item in geoinfo)
                {
                    _repository.InsertGeoinfo(item);
                }

                _repository.Save();
            }

            return geoinfo.ToList();
        }

        public override IEnumerable<Forecast> GetForecasts(Geoinfo geoinfo)
        {
            var _geoinfo = _repository.GetGeoinfoByObject(geoinfo);

            IEnumerable<Forecast> forecasts = null;

            try
            {
                forecasts = _geoinfo.Forecasts.OrderBy(d => d.Day);

                // Om en plats inte har prognoser lägg då till, ändra också om data har gått ut
                if (!forecasts.Any() || _geoinfo.NextUpdate < DateTime.Now)
                {
                    _geoinfo.Forecasts.ToList().ForEach(g => _repository.DeleteForecast(g.ForecastId));

                    // hämta data från webservice
                    var weatherWebservice = new WeatherWebservice();
                    forecasts = weatherWebservice.GetForecast(_geoinfo);

                    // Lägg in data i db
                    foreach (var item in forecasts)
                    {
                        _repository.InsertForecast(item);
                    }

                    _geoinfo.NextUpdate = DateTime.Now.AddMinutes(60);

                    _repository.Save();
                }
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException();
            }

            return forecasts.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}