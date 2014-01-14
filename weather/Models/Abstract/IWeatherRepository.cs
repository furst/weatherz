using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.Models.Abstract
{
    public interface IWeatherRepository : IDisposable
    {
        IEnumerable<Geoinfo> GetGeoinfoByCity(string city);
        Geoinfo GetGeoinfoByObject(Geoinfo geoinfo);
        void UpdateGeoinfo(Geoinfo geoinfo);
        void InsertGeoinfo(Geoinfo geoinfo);

        void DeleteForecast(int forecastId);
        void UpdateForecast(Forecast forecast);
        void InsertForecast(Forecast forecast);

        void Save();
    }
}
