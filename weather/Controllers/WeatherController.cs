using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using weather.Models;
using weather.Models.Webservices;
using weather.ViewModels;

namespace weather.Controllers
{
    public class WeatherController : Controller
    {
        //
        // GET: /Weather/index

        public ActionResult Index()
        {
            var geoinfo = new GeoinfoViewModel();
            return View("index", geoinfo);
        }

        //
        // POST: /Weather/index

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "City")] Geoinfo model)
        {
            var geoinfoViewModel = new GeoinfoViewModel();
            geoinfoViewModel.City = model.City;

            try
            {
                if (ModelState.IsValid)
                {
                    // Hämta data
                    var service = new WeatherService();
                    var geonames = service.GetGeoinfos(model.City);

                    geoinfoViewModel.Geoinfos = geonames;

                    // Om det bara finns en plats så gå direkt till den
                    if (geonames.Count() == 1)
                    {
                        var geoname = geonames.First();
                        return RedirectToAction("Forecast", new { country = geoname.Country, region = geoname.Region, latitude = geoname.Latitude, longitude = geoname.Longitude, city = geoname.City });
                    }

                    return View("index", geoinfoViewModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View("index", geoinfoViewModel);
        }

        //
        // GET: /Weather/Forecast

        public ActionResult Forecast(Geoinfo geoinfo)
        {
            var service = new WeatherService();

            try
            {
                // Hämta data
                var weather = service.GetForecasts(geoinfo);

                var weatherViewModels = new List<WeatherViewModel>();

                // Fyll vymodell
                foreach (var item in weather)
                {
                    var viewModel = new WeatherViewModel(item);
                    weatherViewModels.Add(viewModel);
                }

                // Fyll viewbagen för kartinfo
                ViewBag.City = geoinfo.City;
                ViewBag.Latitude = geoinfo.Latitude;
                ViewBag.Longitude = geoinfo.Longitude;

                return View("forecast", weatherViewModels);
            }
            catch
            {
                return View("error");
            }
        }

    }
}
