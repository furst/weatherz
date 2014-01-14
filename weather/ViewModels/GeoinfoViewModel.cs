using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using weather.Models;

namespace weather.ViewModels
{
    public class GeoinfoViewModel
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [StringLength(50)]
        [DisplayName("Sök")]
        [Required]
        public string City { get; set; }

        public GeoinfoViewModel()
        {
        }

        public GeoinfoViewModel(Geoinfo geoinfo)
        {
            Country = geoinfo.Country;
            Region = geoinfo.Region;
            City = geoinfo.City;
            Latitude = geoinfo.Latitude;
            Longitude = geoinfo.Longitude;
        }

        // Finns det data?
        public bool HasGeoinfos
        {
            get { return Geoinfos != null && Geoinfos.Any(); }
        }

        // Lista data
        public IEnumerable<Geoinfo> Geoinfos { get; set; }
    }
}