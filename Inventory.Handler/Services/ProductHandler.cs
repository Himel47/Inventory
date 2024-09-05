﻿using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Repository.DataContext;
using Inventory.Repository.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Repository.Services
{
    public class ProductHandler : IProductsHandler
    {
        private readonly ApplicationDbContext dbContext;

        public ProductHandler(ApplicationDbContext _dbContext)
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
    }
}
