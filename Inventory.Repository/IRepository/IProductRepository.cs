using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetExistingStockProduct(StockProductDto stockProduct);
        public Task<bool> AddProductAsync(Product product);
        public Task<bool> AddStockProductAsync(StockWithProduct stockProduct);
        public Task<List<StockWithProduct>> GetStockProductsAsync(Guid skuId);
        public Task<Product> GetProductByIdAsync(Guid productId); 
    }
}
