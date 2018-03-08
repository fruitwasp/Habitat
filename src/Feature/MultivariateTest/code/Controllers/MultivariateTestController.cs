using System.Web.Mvc;

namespace Sitecore.Feature.MultivariateTest.Controllers
{
    using Sitecore.ContentTesting;
    using Sitecore.ContentTesting.ContentSearch.Models;
    using System.Collections.Generic;

    public class MultivariateTestController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<TestingSearchResultItem> testingSearchResultItems = ContentTestingFactory.Instance.ContentTestStore.GetActiveTests();
          
            return View(testingSearchResultItems);
        }
    }
}