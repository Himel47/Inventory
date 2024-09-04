﻿using Inventory.DTO.Models;
using Inventory.Repository.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsHandler productHandler;

        public ProductController(IProductsHandler _productHandler)
        {
            productHandler = _productHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var allProducts = await productHandler.GetProductsAsync();
            return View(allProducts);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var response = await productHandler.AddProductAsync();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await productHandler.AddProductAsync(product);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(Guid pId)
        {
            var singleProductDetails = await productHandler.ProductDetailsAsync(pId);
            return View(singleProductDetails);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateData(Guid pId)
        {
            var response = await productHandler.UpdateProductAsync(pId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateData(Product product)
        {
            await productHandler.UpdateProductAsync(product);
            return RedirectToAction("ProductList");
        }

    }
}
