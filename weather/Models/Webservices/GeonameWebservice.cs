using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace weather.Models.Webservices
{
    public class GeonameWebservice
    {
        public IEnumerable<Geoinfo> GetGeoinfo(string city)
        {
            // Hämta data från webservice
            var UrlString = String.Format("http://api.geonames.org/search?name={0}&maxRows=10&style=full&featureClass=P&username=adde", city);
            XmlTextReader reader = new XmlTextReader(UrlString);
            var doc = XDocument.Load(reader);

            // Fyll objekt
            var model = (from geoname in doc.Descendants("geoname")
                         select new Geoinfo
                         {
                             NextUpdate = DateTime.Now.AddMinutes(60),
                             Country = (string)geoname.Element("countryName"),
                             Region = (string)geoname.Element("adminName1"),
                             City = (string)geoname.Element("toponymName"),
                             Latitude = (string)geoname.Element("lat"),
                             Longitude = (string)geoname.Element("lng")
                         }).ToList();

            return model;
        }
    }
}