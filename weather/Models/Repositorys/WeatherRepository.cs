using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weather.Models.Abstract;
using weather.Models.DataModels;

namespace weather.Models.Repositorys
{
    public class WeatherRepository : WeatherRepositoryBase
    {
        private WeatherEntities _context = new WeatherEntities();

        // Geoinfo
        protected override IQueryable<Geoinfo> QueryGeoinfo()
        {
            return _context.Geoinfoes.AsQueryable();
        }

        public override void UpdateGeoinfo(Geoinfo geoinfo)
        {
            _context.Entry(geoinfo).State = System.Data.EntityState.Modified;
        }

        public override void InsertGeoinfo(Geoinfo geoinfo)
        {
            _context.Geoinfoes.Add(geoinfo);
        }

        // Forecasts
        public override void DeleteForecast(int forecastId)
        {
            Forecast forecast = _context.Forecasts.Find(forecastId);
            _context.Forecasts.Remove(forecast);
        }

        public override void UpdateForecast(Forecast forecast)
        {
            _context.Entry(forecast).State = System.Data.EntityState.Modified;
        }

        public override void InsertForecast(Forecast forecast)
        {
            _context.Forecasts.Add(forecast);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }

        // Dispose

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                } 
            }
            _disposed = true;

            base.Dispose(disposing);
        }

        
    }
}