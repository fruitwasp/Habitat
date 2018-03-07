using System.Collections.Generic;
using Sitecore.Data.Items;

namespace Sitecore.Feature.MultivariateTest.Repositories
{
    public interface IMultivariateTestRepository
    {
        IEnumerable<Item> Get(Item contextItem);
        IEnumerable<Item> GetLatest(Item contextItem, int count);
    }
}
