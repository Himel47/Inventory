using Inventory.DTO.Models;
using Inventory.Repository.DataContext;
using Inventory.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repository.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext dbContext;

        public StockRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<Stock>> GetAllStocks()
        {
            var allStocks = await dbContext.Stocks.ToListAsync();
            return allStocks;
        }

        public async Task<bool> AddStockAsync(Stock stock)
        {
            try
            {
                await dbContext.Stocks.AddAsync(stock);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Stock> GetStockById(Guid skuId)
        {
            var stock = await dbContext.Stocks.Where(x => x.skuId == skuId)
                .SingleOrDefaultAsync();
            return stock;
        }

        public async Task<bool> SaveDbChanges()
        {
            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
