using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;

namespace MvcApp.Tests
{
    [Subject("Routing")]
    public class Test_DefaultRoute_WithoutId
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/");

        It shouldBeHomeIndex = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("Index");
            routeData.Values["Id"].ShouldEqual(UrlParameter.Optional);
        };
    }

    [Subject("Routing")]
    public class Test_DefaultRoute_WithId
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/Home/Index/56");

        It shouldBeHomeIndex56 = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("Index");
            routeData.Values["Id"].ShouldEqual("56");
        };
    }
}
