using Inventory.AggregateRoot.Models;
using Inventory.DTO.DTOs;
using Inventory.DTO.ViewModels;

namespace Inventory.Repository.IServices
{
    public interface IProductsHandler
    {
        Task<List<StockProductDto>> GetProductsAsync();
        Task<AddProductViewModel> AddProductAsync();
        Task<Product> AddProductAsync(StockProductDto product);
        Task<Product> ProductDetailsAsync(string productName, int categoryId);
    }
}
