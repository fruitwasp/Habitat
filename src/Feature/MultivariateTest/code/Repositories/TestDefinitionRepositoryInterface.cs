using Sitecore.Data.Items;
using System.Collections.Generic;

namespace Sitecore.Feature.MultivariateTest.Repositories
{
    public interface TestDefinitionRepositoryInterface
    {
        IEnumerable<Item> Get(Item contextItem);
        IEnumerable<Item> GetLatest(Item contextItem, int count);
    }
}
