using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Moq;

namespace MvcApp.Tests
{
    public static class RoutingHelper
    {
        public static RouteData GetRouteData(string url)
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            return routes.GetRouteData(httpContext.Object);
        }
    }
}
