using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace weather.Models.Webservices
{
    public class WeatherWebservice
    {
        public List<Forecast> GetForecast(Geoinfo geoinfo)
        {
            // Kod för att hämta från xml-fil
            //var path = HttpContext.Current.Server.MapPath("~/App_Data/gvarv.xml");
            //var doc = XDocument.Load(path);

            // Kod för webservice
            var UrlString = String.Format("http://www.yr.no/place/{0}/{1}/{2}/forecast.xml", geoinfo.Country, geoinfo.Region, geoinfo.City);
            XmlTextReader reader = new XmlTextReader(UrlString);
            var doc = XDocument.Load(reader);

            var model = (from time in doc.Descendants("time")
                         where (int)time.Attribute("period") == 2 || (int)time.Attribute("period") == 3
                         select new Forecast
                         {
                             Day = DateTime.ParseExact((string)time.Attribute("from"), "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                             Temperature = (int)time.Element("temperature").Attribute("value"),
                             Period = (int)time.Attribute("period"),
                             Symbol = (int)time.Element("symbol").Attribute("number"),
                             GeoinfoId =  geoinfo.GeoinfoId,
                         }).ToList();

            model = Clear(model);

            return model;
        }

        // Rensa data så endast rätt period finns med
        private List<Forecast> Clear(IEnumerable<Forecast> model)
        {
            var newModel = new List<Forecast>();

            foreach (var item in model)
            {
                if (newModel.Count != 0)
                {
                    if (item.Period == 2)
                    {
                        newModel.Add(item);
                    }
                }
                else
                {
                    newModel.Add(item);
                }

                if (newModel.Count >= 5)
                {
                    break;
                }
            }

            return newModel;
        }
    }
}