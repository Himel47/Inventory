using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.AggregateRoot
{
    public interface IOperations
    {
        Task<List<ECategoryTypes>> GetCategories();
    }
}
