using Inventory.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.IRepository
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllStocks();
        public Task<bool> AddStockAsync(Stock stock);
        public Task<bool> SaveDbChanges();
        public Task<Stock> GetStockById(Guid skuId);

    }
}
