using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using Moq;
using System.Web.Routing;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void TestIncomingRoutes()
        {
            //TestRouteMatch("~/Admin/Index", "Admin", "Index");
            //TestRouteMatch("~/One/Two", "One", "Two");
            //TestRouteFailed("~/Admin/Index/Segment");
            //TestRouteFailed("~/Admin");

            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Customer", "Customer", "Index");
            TestRouteMatch("~/Customer/List", "Customer", "List");
            TestRouteFailed("~/Customer/List/All");
            TestRouteMatch("~/Shop/Index", "Home", "Index");
        }

        HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            // Create mock request
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // Create mock response
            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // Create the mock context, using th request and response
            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        void TestRouteMatch(string url, string expectedController, string expectedAction, object routeProperties = null, string httpMethod = "GET")
        {
            // Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncommingRouteResult(result, expectedController, expectedAction, routeProperties));
        }

        void TestRouteFailed(string url)
        {
            // Arrange
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act
            var result = routes.GetRouteData(CreateHttpContext(url));

            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }

        bool TestIncommingRouteResult(RouteData routeResult, string expetedController, string expectedAction, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) => StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;

            var result = valCompare(routeResult.Values["controller"], expetedController) 
                && valCompare(routeResult.Values["action"], expectedAction);

            if (propertySet != null)
            {
                var propInfo = propertySet.GetType().GetProperties();
                foreach(var prop in propInfo)
                {
                    if(!(routeResult.Values.ContainsKey(prop.Name) && valCompare(routeResult.Values[prop.Name], prop.GetValue(propertySet,null))))
                    {
                        return false;
                    }
                }
            }

            return result;
        }
    }
}
