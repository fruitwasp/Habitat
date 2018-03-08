using System.Web.Mvc;

namespace Sitecore.Feature.MultivariateTest.Controllers
{
    using Sitecore.ContentTesting;
    using Sitecore.ContentTesting.ContentSearch.Models;
    using Sitecore.ContentTesting.Model;
    using Sitecore.ContentTesting.Model.Data.Items;
    using Sitecore.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MultivariateTestController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<TestingSearchResultItem> testingSearchResultItems = ContentTestingFactory.Instance.ContentTestStore.GetActiveTests();

            var testingSearchResultItem = testingSearchResultItems.First();

            var item = Database.GetItem(testingSearchResultItem.Uri);
            var testDefinitionItem = TestDefinitionItem.Create(item);

            var hostItem = item.Database.GetItem(testingSearchResultItem.HostItemUri);

            ITestConfiguration configuration = ContentTestingFactory.Instance.ContentTestStore.LoadTestForItem(hostItem, testDefinitionItem);

            IEnumerable<TestExperience> experiences = configuration.Experiences;

            var textExperience = experiences.First();

            IEnumerable<Guid> variantIds = textExperience.Variants;

            var variantId = variantIds.First().ToString();

            return View(null, null, variantId);
        }
    }
}