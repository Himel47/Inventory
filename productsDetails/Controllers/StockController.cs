using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Handler.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockHandler stockHandler;

        public StockController(IStockHandler _stockHandler)
        {
            stockHandler = _stockHandler;
        }

        [HttpGet]
        public async Task<IActionResult> StockList()
        {
            var response = await stockHandler.GetStocksAsync();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewStock()
        {
            var response = await stockHandler.AddStockAsync();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStock(Stock newStock)
        {
            var response = await stockHandler.AddStockAsync(newStock);
            return RedirectToAction("AddProductsToStock",response);
        }

        [HttpGet]
        public async Task<IActionResult> AddProductsToStock(Stock stock)
        {
            var response = await stockHandler.AddProductsToStockAsync(stock);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductsToStock(StockViewModel vm)
        {
            var response = await stockHandler.AddProductsToStockAsync(vm);
            return RedirectToAction("StockList");
        }

        [HttpGet]
        public async Task<IActionResult> StockDetails(Guid skuId)
        {
            var singleProductDetails = await stockHandler.StockDetailsAsync(skuId);
            return View(singleProductDetails);
        }
    }
}
