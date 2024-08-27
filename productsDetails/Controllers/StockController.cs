using Microsoft.AspNetCore.Mvc;
using productsDetails.Models;
using productsDetails.ServiceInterfaces;
using productsDetails.ViewModels;

namespace productsDetails.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockServices services;

        public StockController(IStockServices _services)
        {
            services = _services;
        }

        [HttpGet]
        public async Task<IActionResult> StockList()
        {
            var response = await services.GetStocksAsync();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewStock()
        {
            var response = await services.AddStockAsync();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStock(AddStockViewModel vm)
        {
            var response = await services.AddStockAsync(vm);
            return RedirectToAction("StockList");
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(Guid skuId)
        {
            var singleProductDetails = await services.StockDetailsAsync(skuId);
            return View(singleProductDetails);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateData(Guid skuId)
        {
            var response = await services.UpdateStockAsync(skuId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateData(Stock stock)
        {
            await services.UpdateStockAsync(stock);
            return RedirectToAction("ProductList");
        }
    }
}
