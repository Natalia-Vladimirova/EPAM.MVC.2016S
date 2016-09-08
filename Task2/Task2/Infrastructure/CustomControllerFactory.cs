using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Task2.Controllers;

namespace Task2.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {
                case "Home":
                    targetType = typeof(HomeController);
                    break;
                case "User":
                    targetType = typeof(UserController);
                    break;
                case "Customer":
                    targetType = typeof(UserController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "User";
                    targetType = typeof(UserController);
                    break;
            }
            return targetType == null
                ? null
                : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            switch (controllerName)
            {
                case "Home":
                    return SessionStateBehavior.Disabled;
                default:
                    return SessionStateBehavior.Default;
            }
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}