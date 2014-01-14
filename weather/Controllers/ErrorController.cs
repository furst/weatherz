using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace weather.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ViewResult Index()
        {
            return View("Error");
        }

        public ViewResult PageNotFound()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;

            return View("404");
        }

        public ViewResult SomethingWentWrong()
        {
            Response.StatusCode = 505;
            Response.TrySkipIisCustomErrors = true;

            return View("505");
        }

    }
}
