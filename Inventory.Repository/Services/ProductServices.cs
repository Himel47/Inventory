using Inventory.DTO.DTOs;
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

        public async Task<List<StockProductDto>> GetProductsAsync()
        {
            List<StockProductDto> products = new List<StockProductDto>();
            var allProducts = await dbContext.Products.ToListAsync();
            if (allProducts != null)
            {
                foreach(var product in allProducts)
                {
                    products.Add(new StockProductDto
                    {
                        productName = product.productName,
                        productDesc = product.productDesc,
                        productUnitPrice = product.productUnitPrice,
                        productQuantity = product.productQuantity,
                        ProductViewPicture = Convert.ToBase64String(product.productImageByteString),
                        ProductViewPictureFormat = product.productImage,
                        categoryId = product.categoryId
                    });
                }
            }
            return products;
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
