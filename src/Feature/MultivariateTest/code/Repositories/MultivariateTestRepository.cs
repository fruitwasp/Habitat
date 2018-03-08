using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Foundation.DependencyInjection;
using Sitecore.Foundation.Indexing.Models;
using Sitecore.Foundation.Indexing.Repositories;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Feature.MultivariateTest.Repositories
{
    [Service(typeof(IMultivariateTestRepository))]
    public class MultivariateTestRepository : IMultivariateTestRepository
    {
        private readonly ISearchServiceRepository searchServiceRepository;

        public MultivariateTestRepository(ISearchServiceRepository searchServiceRepository)
        {
            this.searchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<Item> Get(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }

            if (!contextItem.IsDerived(Templates.MultivariateTestFolder.ID))
            {
                throw new ArgumentException("Item must derive from MultivariateTestFolder", nameof(contextItem));
            }

            var searchService = this.searchServiceRepository.Get(new SearchSettingsBase { Templates = new[] { Templates.MultivariateTest.ID } });
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