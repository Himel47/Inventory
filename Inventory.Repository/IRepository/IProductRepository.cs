using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.IRepository
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<Product> GetExistingStockProduct(StockProductDto stockProduct);
        Task<List<StockWithProduct>> GetStockProductsAsync(Guid skuId);
        Task<Product> GetProductByName(string name, int categoryId);
    }
}
