using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.Repository.DataContext;
using Inventory.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext _dbContext) : base(_dbContext) 
        {
            dbContext = _dbContext;
        }

        public async Task<Product> GetExistingStockProduct(StockProductDto stockProduct)
        {
            var existingProduct = await dbContext.Products
                        .Where(x => x.productName == stockProduct.productName
                            && x.categoryId == stockProduct.categoryId)
                        .SingleOrDefaultAsync();
            return existingProduct;
        }
        public async Task<bool> AddStockProductAsync(StockWithProduct stockProduct)
        {
            try
            {
                await dbContext.StockProducts.AddAsync(stockProduct);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<StockWithProduct>> GetStockProductsAsync(Guid skuId)
        {
            var productsInStock = await dbContext.StockProducts
                .Where(x => x.stockId == skuId)
                .ToListAsync();
            return productsInStock;
        }
    }
}
