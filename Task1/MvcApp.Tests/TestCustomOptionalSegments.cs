using System.Web.Mvc;
using System.Web.Routing;
using Machine.Specifications;

namespace MvcApp.Tests
{
    [Subject("Routing")]
    public class Test_CustomParamName
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/CustomOptional");

        It paramNameShouldBeParam = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("CustomOptional");
            routeData.Values["Param"].ShouldNotBeNull();
        };
    }

    [Subject("Routing")]
    public class Test_OptionalParam
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/CustomOptional");

        It paramShouldBeOptional = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("CustomOptional");
            routeData.Values["Param"].ShouldEqual(UrlParameter.Optional);
        };
    }

    [Subject("Routing")]
    public class Test_CustomParamStr
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/CustomOptional/str");

        It paramShouldBeStr = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("CustomOptional");
            routeData.Values["Param"].ShouldEqual("str");
        };
    }
}