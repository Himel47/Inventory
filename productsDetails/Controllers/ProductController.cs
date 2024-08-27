using Microsoft.AspNetCore.Mvc;
using productsDetails.Models;
using productsDetails.ServiceInterfaces;

namespace productsDetails.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsServices pServices;

        public ProductController(IProductsServices _pServices)
        {
            pServices = _pServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var allProducts = await pServices.GetProductsAsync();
            return View(allProducts);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var response = await pServices.AddProductAsync();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await pServices.AddProductAsync(product);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> StockDetails(Guid pId)
        {
            var singleProductDetails = await pServices.ProductDetailsAsync(pId);
            return View(singleProductDetails);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateData(Guid pId)
        {
            var response = await pServices.UpdateProductAsync(pId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateData(Product product)
        {
            await pServices.UpdateProductAsync(product);
            return RedirectToAction("ProductList");
        }

    }
}
