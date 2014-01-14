using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather.Models.Abstract
{
    public interface IWeatherService : IDisposable
    {
        IEnumerable<Geoinfo> GetGeoinfos(string city);
        IEnumerable<Forecast> GetForecasts(Geoinfo geoinfo);
    }
}
