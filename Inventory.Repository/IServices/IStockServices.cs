﻿using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;


namespace Inventory.Repository.IServices
{
    public interface IStockServices
    {
        public Task<List<Stock>> GetStocksAsync();
        public Task<StockViewModel> StockDetailsAsync(Guid skuId);
        public Task<Stock> AddStockAsync();
        public Task<Stock> AddStockAsync(Stock st);
        public Task<StockViewModel> AddProductsToStockAsync(Stock stock);
        public Task<StockViewModel> AddProductsToStockAsync(StockViewModel vm);
        public Task<Stock> UpdateStockAsync(Guid skuId);
        public Task<Stock> UpdateStockAsync(Stock stock);
        public Task<Stock> RemoveStockAsync(Guid skuId);
    }
}
