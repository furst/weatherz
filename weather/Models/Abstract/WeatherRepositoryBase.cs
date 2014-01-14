using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weather.Models.Abstract
{
    public abstract class WeatherRepositoryBase : IWeatherRepository
    {
        #region IWeatherRepository Members

        // Geoinfo
        protected abstract IQueryable<Geoinfo> QueryGeoinfo();

        public IEnumerable<Geoinfo> GetGeoinfoByCity(string city)
        {
            return QueryGeoinfo().Where(c => c.City.Contains(city));
        }

        public Geoinfo GetGeoinfoByObject(Geoinfo geoinfo)
        {
            return QueryGeoinfo().SingleOrDefault(m => m.Country == geoinfo.Country && m.Region == geoinfo.Region && m.City == geoinfo.City);
        }

        public abstract void UpdateGeoinfo(Geoinfo geoinfo);
        public abstract void InsertGeoinfo(Geoinfo geoinfo);

        // Forecast
        public abstract void DeleteForecast(int forecastId);
        public abstract void UpdateForecast(Forecast forecast);
        public abstract void InsertForecast(Forecast forecast);

        public abstract void Save();

        #endregion

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}