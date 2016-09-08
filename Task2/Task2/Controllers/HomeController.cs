using System.Web.Mvc;
using System.Web.SessionState;
using Task2.Models;

namespace Task2.Controllers
{
    // 1 version of app - using attributes
    [SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(new Info
            {
                ControllerName = $"{nameof(HomeController)}",
                ActionName = $"{nameof(Index)}"
            });
        }
    }
}