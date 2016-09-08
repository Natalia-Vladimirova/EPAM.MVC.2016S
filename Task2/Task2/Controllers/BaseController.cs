using System.Web.Mvc;

namespace Task2.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write($"404: action '{actionName}' not found.");
        }
    }
}