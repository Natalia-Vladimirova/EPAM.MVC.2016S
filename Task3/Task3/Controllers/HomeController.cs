using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Person");
        }

        [HttpPost]
        public ActionResult GetFooter(string action)
        {
            if (action == "yes")
            {
                //ExcelReport(model);
            }
            else if (action == "no")
            {

              //  return GetReport(model);
            }

          //  return PartialView("_Footer");
        }

    }
}