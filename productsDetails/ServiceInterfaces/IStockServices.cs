using productsDetails.Models;
using productsDetails.ViewModels;

namespace productsDetails.ServiceInterfaces
{
    public interface IStockServices
    {
        public Task<List<Stock>> GetStocksAsync();
        public Task<Stock> StockDetailsAsync(Guid skuId);
        public Task<AddStockViewModel> AddStockAsync();
        public Task<AddStockViewModel> AddStockAsync(AddStockViewModel stock);
        public Task<Stock> UpdateStockAsync(Guid skuId);
        public Task<Stock> UpdateStockAsync(Stock stock);
        public Task<Stock> RemoveStockAsync(Guid skuId);
    }
}
