using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.Repository.DataContext;
using Inventory.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<StockWithProduct>> GetStockProductsAsync(Guid skuId)
        {
            var productsInStock = await dbContext.StockProducts
                .Where(x => x.stockId == skuId)
                .ToListAsync();
            return productsInStock;
        }

        public async Task<Product> GetProductByName(string name, int categoryId)
        {
            var product = await dbContext.Products.SingleOrDefaultAsync(x=>x.productName==name && x.categoryId==categoryId);

            return product;
        }
    }
}
