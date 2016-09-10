using System.Web.Mvc;
using Task4.Models;

namespace Task4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Person");
        }

        [HttpGet]
        public ActionResult Person()
        {
            var person = new Person();
            if (TryUpdateModel(person, new QueryStringValueProvider(ControllerContext)))
            {
                return View("Person", person);
            }
            return View("Person");
        }

        [HttpPost]
        [ActionName("Person")]
        public ActionResult PersonPost()
        {
            var person = new Person();
            if (TryUpdateModel(person, new FormValueProvider(ControllerContext)))
            {
                return View("Person", person);
            }
            return View("Person");
        }
    }
}