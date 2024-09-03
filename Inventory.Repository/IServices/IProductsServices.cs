using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;

namespace Inventory.Repository.IServices
{
    public interface IProductsServices
    {
        public Task<List<StockProductDto>> GetProductsAsync();
        public Task<Product> ProductDetailsAsync(Guid productId);
        public Task<AddProductViewModel> AddProductAsync();
        public Task<Product> AddProductAsync(Product product);
        public Task<Product> UpdateProductAsync(Guid productId);
        public Task<Product> UpdateProductAsync(Product product);
        public Task<Product> RemoveProductAsync(Guid productId);
    }
}
