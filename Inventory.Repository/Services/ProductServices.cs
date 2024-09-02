using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Repository.DataContext;
using Inventory.Repository.IServices;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace Inventory.Repository.Services
{
    public class ProductServices : IProductsServices
    {
        private readonly ApplicationDbContext dbContext;

        public ProductServices(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<AddProductViewModel> AddProductAsync()
        {
            var categories = await dbContext.Categories.ToListAsync();

            var vm = new AddProductViewModel
            {
                Categories = new SelectList(categories, "categoryName", "categoryId")
            };
            return vm;
        }

        public Task<Product> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await dbContext.Products.ToListAsync();
            return response;
        }

        public Task<Product> ProductDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> ProductDetailsAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> RemoveProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
