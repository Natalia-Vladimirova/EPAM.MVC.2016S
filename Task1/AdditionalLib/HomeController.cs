using System.Web.Mvc;

namespace AdditionalLib
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Json(new {
                Library = $"{nameof(AdditionalLib)}",
                Controller = $"{nameof(HomeController)}",
                Method = $"{nameof(Index)}",
                Message = "Namespace priority (Json)"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
