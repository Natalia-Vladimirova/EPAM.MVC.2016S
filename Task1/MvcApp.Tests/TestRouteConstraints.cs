using System.Web.Routing;
using Machine.Specifications;

namespace MvcApp.Tests
{
    [Subject("Routing")]
    public class Test_RouteConstraints_IntId_Value1000
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/Constraints/1000");

        It shouldBeHomeConstraintsWithIntIdValue1000 = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("Constraints");
            routeData.Values["Id"].ShouldEqual("1000");
        };
    }

    [Subject("Routing")]
    public class Test_RouteConstraints_IntId_Length2
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/Constraints/12");

        It shouldBeHomeConstraintsWithIntIdValue12 = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Controller"].ShouldEqual("Home");
            routeData.Values["Action"].ShouldEqual("Constraints");
            routeData.Values["Id"].ShouldEqual("12");
        };
    }

    [Subject("Routing")]
    public class Test_RouteConstraints_NotIntId_Length3_ValueStr
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/Constraints/str");

        It idShouldNotEqualStr = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Action"].ShouldNotEqual("Constraints");
            routeData.Values["Id"].ShouldNotEqual("str");
        };
    }

    [Subject("Routing")]
    public class Test_RouteConstraints_IntId_Length1
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/Constraints/5");
        
        It idShouldNotEqual5 = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Action"].ShouldNotEqual("Constraints");
            routeData.Values["Id"].ShouldNotEqual("5");
        };
    }
    
    [Subject("Routing")]
    public class Test_RouteConstraints_IntId_Value1001
    {
        private static RouteData routeData;

        Establish that = () => routeData = RoutingHelper.GetRouteData("~/Constraints/1001");

        It idShouldNotEqual1001 = () =>
        {
            routeData.ShouldNotBeNull();
            routeData.Values["Action"].ShouldNotEqual("Constraints");
            routeData.Values["Id"].ShouldNotEqual("1001");
        };
    }
}
