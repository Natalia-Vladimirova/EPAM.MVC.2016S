using System.Web.Routing;
using Machine.Specifications;

namespace MvcApp.Tests
{
    [Subject("Routing")]
    public class Test_StaticRoute
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/Home/Static");

        It shouldBeHomeStatic = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("Static");
        };
    }
}
