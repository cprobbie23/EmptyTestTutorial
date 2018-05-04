using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;

namespace Spike_TESTS.Tests.Unit.Infrastructure
{
    public static class ActionResultExtension 
    {
        public static string DefaultMVCViewName = string.Empty;

        public static T Model<T>(this ActionResult result) where T : class
        {
            if (!(result is ViewResultBase))
                throw new ArgumentException(@"The object is not of type ViewResultBase or one of its subtypes", nameof(result));
            
            var viewresult = (ViewResultBase)result;
            return viewresult.Model as T;
        }

        public static void ViewShouldBe(this ActionResult result, string expectedView) 
        {
            if (!(result is ViewResultBase))
                throw new ArgumentException(@"The object is not of type ViewResultBase or one of its subtypes", nameof(result));

            var viewresult = (ViewResultBase)result;
            Assert.AreEqual(expectedView, viewresult.ViewName);
        }

        public static ActionResult ShouldRedirectTo(this ActionResult result, string expectedAction, string expectedController)
        {
            if (!(result is RedirectToRouteResult))
                throw new ArgumentException(@"The object is not of type RedirectToRouteResult or one of its subtypes", nameof(result));

            var redirect = (RedirectToRouteResult)result;
            Assert.AreEqual(expectedAction, redirect.RouteValues["action"]);
            Assert.AreEqual(expectedController, redirect.RouteValues["controller"]);

            return result;
        }

        public static void WithUrlParams(this ActionResult result, IDictionary<string, object> expectedUrlParams)
        {
            var redirect = (RedirectToRouteResult)result;
            foreach (var urlParamName in expectedUrlParams.Keys)
            {
                Assert.AreEqual(expectedUrlParams[urlParamName], redirect.RouteValues[urlParamName]);
            }
        }
    }
}