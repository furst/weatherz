using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weather.Models.Abstract
{
    public abstract class WeatherServiceBase : IWeatherService
    {
        #region IWeatherService Members

        public abstract IEnumerable<Geoinfo> GetGeoinfos(string city);
        public abstract IEnumerable<Forecast> GetForecasts(Geoinfo geoinfo);

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