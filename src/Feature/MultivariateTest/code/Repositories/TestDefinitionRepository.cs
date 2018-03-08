using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentTesting.Model.Data.Items;
using Sitecore.Data.Items;
using Sitecore.Foundation.DependencyInjection;
using Sitecore.Foundation.Indexing.Models;
using Sitecore.Foundation.Indexing.Repositories;

namespace Sitecore.Feature.MultivariateTest.Repositories
{
    [Service(typeof(TestDefinitionRepositoryInterface))]
    public class TestDefinitionRepository : TestDefinitionRepositoryInterface
    {
        private readonly ISearchServiceRepository searchServiceRepository;

        public TestDefinitionRepository(ISearchServiceRepository searchServiceRepository)
        {
            this.searchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<Item> Get(Item contextItem)
        {
            var searchService = this.searchServiceRepository.Get(new SearchSettingsBase { Templates = new[] { TestDefinitionItem.TemplateID } });
            searchService.Settings.Root = contextItem;

            var results = searchService.FindAll();
            return results.Results.Select(x => x.Item).Where(x => x != null);
        }

        public IEnumerable<Item> GetLatest(Item contextItem, int count)
        {
            return Get(contextItem).Take(count);
        }
    }
}