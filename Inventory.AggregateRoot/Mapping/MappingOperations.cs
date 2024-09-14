using Inventory.AggregateRoot.IMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.AggregateRoot.Mapping
{
    public class MappingOperations : IMappingOperations
    {
        public async Task<List<ECategoryTypes>> GetCategories()
        {
            List<ECategoryTypes> categories = Enum.GetValues(typeof(ECategoryTypes)).Cast<ECategoryTypes>().ToList();

            return categories;
        }
    }
}
