using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Repository.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
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
        public async Task<IActionResult> AddNewStock(Stock newStock)
        {
            var response = await services.AddStockAsync(newStock);
            return RedirectToAction("AddProductsToStock",response);
        }

        [HttpGet]
        public async Task<IActionResult> AddProductsToStock(Stock stock)
        {
            var response = await services.AddProductsToStockAsync(stock);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductsToStock(StockViewModel vm)
        {
            var response = await services.AddProductsToStockAsync(vm);
            return RedirectToAction("StockList");
        }

        [HttpGet]
        public async Task<IActionResult> StockDetails(Guid skuId)
        {
            var singleProductDetails = await services.StockDetailsAsync(skuId);
            return View(singleProductDetails);
        }
    }
}
