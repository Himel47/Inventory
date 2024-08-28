using productsDetails.Models;
using productsDetails.ViewModels;

namespace productsDetails.ServiceInterfaces
{
    public interface IStockServices
    {
        public Task<List<Stock>> GetStocksAsync();
        public Task<StockViewModel> StockDetailsAsync(Guid skuId);
        public Task<StockViewModel> AddStockAsync();
        public Task<StockViewModel> AddStockAsync(StockViewModel stock);
        public Task<Stock> UpdateStockAsync(Guid skuId);
        public Task<Stock> UpdateStockAsync(Stock stock);
        public Task<Stock> RemoveStockAsync(Guid skuId);
    }
}
