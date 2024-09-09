using Inventory.AggregateRoot.Models;
using Inventory.DTO.ViewModels;


namespace Inventory.Handler.IServices
{
    public interface IStockHandler
    {
        Task<List<Stock>> GetStocksAsync();
        Task<StockViewModel> StockDetailsAsync(Guid skuId);
        Task<Stock> AddStockAsync();
        Task<Stock> AddStockAsync(Stock st);
        Task<StockViewModel> AddProductsToStockAsync(Stock stock);
        Task<StockViewModel> AddProductsToStockAsync(StockViewModel vm);
    }
}
