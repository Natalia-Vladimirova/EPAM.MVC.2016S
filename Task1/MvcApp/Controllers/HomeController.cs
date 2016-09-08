using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Default Routes";
            return View("All");
        }

        public ActionResult Static()
        {
            ViewBag.Message = "Static segments";
            return View("All");
        }

        public ActionResult CustomOptional(string param)
        {
            ViewBag.Message = $"Custom optional segment (param: {param})";
            return View("All");
        }
        
        public ActionResult Constraints(string id)
        {
            ViewBag.Message = $"Route constraints (id: {id})";
            return View("All");
        }
        
    }
}