using Inventory.AggregateRoot.Models;
using Inventory.DTO.DTOs;

namespace Inventory.Repository.IRepository
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<Product> GetExistingStockProduct(StockProductDto stockProduct);
        Task<List<StockWithProduct>> GetStockProductsAsync(Guid skuId);
        Task<Product> GetProductByName(string name, int categoryId);
    }
}
