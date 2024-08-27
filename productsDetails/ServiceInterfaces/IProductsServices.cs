using productsDetails.Models;
using productsDetails.ViewModels;

namespace productsDetails.ServiceInterfaces
{
    public interface IProductsServices
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> ProductDetailsAsync(Guid productId);
        public Task<AddProductViewModel> AddProductAsync();
        public Task<Product> AddProductAsync(Product product);
        public Task<Product> UpdateProductAsync(Guid productId);
        public Task<Product> UpdateProductAsync(Product product);
        public Task<Product> RemoveProductAsync(Guid productId);
    }
}
