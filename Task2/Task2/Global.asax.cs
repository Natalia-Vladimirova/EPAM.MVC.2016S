using System.Web.Mvc;
using System.Web.Routing;
using Task2.Infrastructure;

namespace Task2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // 2 version of app - using custom factory
            // ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
        }
    }
}
