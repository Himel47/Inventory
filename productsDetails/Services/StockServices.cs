using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using productsDetails.Data;
using productsDetails.Models;
using productsDetails.ServiceInterfaces;
using productsDetails.ViewModels;

namespace productsDetails.Services
{
    public class StockServices : IStockServices
    {
        private readonly ApplicationDbContext dbContext;

        public StockServices(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<Stock>> GetStocksAsync()
        {
            var response = await dbContext.Stocks.ToListAsync();
            return response;
        }

        public async Task<AddStockViewModel> AddStockAsync()
        {
            return new AddStockViewModel();
        }

        public async Task<AddStockViewModel> AddStockAsync(AddStockViewModel vm)
        {

            await dbContext.Stocks.AddAsync(vm.stock);
            dbContext.SaveChanges();
            return vm;
        }

        public Task<Stock> RemoveStockAsync(Guid stockId)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> StockDetailsAsync(Guid skuId)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> UpdateStockAsync(Guid skuId)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> UpdateStockAsync(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
