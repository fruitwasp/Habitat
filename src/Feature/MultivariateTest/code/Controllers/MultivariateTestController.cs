using System.Web.Mvc;

namespace Sitecore.Feature.MultivariateTest.Controllers
{
    using Sitecore.ContentTesting;
    using Sitecore.ContentTesting.ContentSearch.Models;
    using Sitecore.ContentTesting.Model;
    using Sitecore.ContentTesting.Model.Data.Items;
    using Sitecore.ContentTesting.Models;
    using Sitecore.Data;
    using Sitecore.Data.Items;
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

            //return View(null, null, testDefinitionItem);

            var hostItem = item.Database.GetItem(testingSearchResultItem.HostItemUri);

            ITestConfiguration configuration = ContentTestingFactory.Instance.ContentTestStore.LoadTestForItem(hostItem, testDefinitionItem);

            return View(null, null, configuration.DeviceName);

            //IEnumerable<TestExperience> experiences = configuration.Experiences;

            //TestExperience textExperience = experiences.First();

            //IEnumerable<Guid> variantIds = textExperience.Variants;

            //var variantId = variantIds.First();

            //return View(null, null, variantId);

            //var variantItem = Context.Database.GetItem(new ID(variantId));
            //return View(null, null, variantItem);

            //var variables = configuration.Variables;

            //TestSet testSet = configuration.TestSet;

            //TestValueCollection testValueCollection = testSet.Variables[0].Values;
            //var testValue = testValueCollection[0];

            //return View(null, null, testValue);
        }

        private TestDebugInfo CreateTestDebugInfo(Item item)
        {
            TestDebugInfo testDebugInfo = new TestDebugInfo
            {
                itemPath = "",
                itemUri = item.Uri,
                templateName = item.TemplateName
            };

            return testDebugInfo;
        }
    }

    public struct TestDebugInfo
    {
        public string itemPath;
        public ItemUri itemUri;
        public string templateName;
    }
}