using System.Web.Mvc;
using Task2.Controllers;

namespace Task2.Infrastructure
{
    public class CustomActionInvoker : IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (controllerContext.Controller.GetType() == typeof(AdminController) && controllerContext.HttpContext.Request.IsLocal)
            {
                return false;
            }

            return true;
        }
    }
}