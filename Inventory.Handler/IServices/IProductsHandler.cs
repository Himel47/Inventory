using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;

namespace Inventory.Repository.IServices
{
    public interface IProductsHandler
    {
        Task<List<StockProductDto>> GetProductsAsync();
        Task<AddProductViewModel> AddProductAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product> ProductDetailsAsync(string productName, int categoryId);
    }
}
