using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.AggregateRoot.IMapping
{
    public interface IMappingOperations
    {
        Task<List<ECategoryTypes>> GetCategories();
    }
}
