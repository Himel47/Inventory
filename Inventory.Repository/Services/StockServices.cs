using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Repository.DataContext;
using Inventory.Repository.IServices;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repository.Services
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

        public async Task<Stock> AddStockAsync()
        {
            return new Stock();
        }

        public async Task<Stock> AddStockAsync(Stock st)
        {
            await dbContext.Stocks.AddAsync(st);
            await dbContext.SaveChangesAsync();

            return st;
        }

        public async Task<StockViewModel> AddProductsToStockAsync(Stock st)
        {
            var vm = new StockViewModel
            {
                stock = st,
                products = Enumerable.Range(0, st.ProductNumber)
                    .Select(i => new StockProductDto())
                    .ToList()
            };

            return vm;
        }

        public async Task<StockViewModel> AddProductsToStockAsync(StockViewModel vm)
        {
            if (vm.products != null && vm.products.Count != 0)
            {
                foreach (var product in vm.products)
                {
                    var existedProduct = await dbContext.Products
                        .Where(x => x.productName == product.productName
                            && x.categoryId == product.categoryId)
                        .FirstOrDefaultAsync();
                    if (existedProduct != null)
                    {
                        existedProduct.productQuantity += product.productQuantity;
                    }
                    else
                    {
                        var newProduct = new Product
                        {
                            productName = product.productName,
                            productDesc = product.productDesc,
                            //productImage = product.productImage.ContentType,
                            productStatus = "In Stock",
                            productQuantity = product.productQuantity,
                            productUnitPrice = product.productUnitPrice
                        };

                        /*var mStream = new MemoryStream();
                        product.productImage.CopyTo(mStream);
                        newProduct.productImageByteString = mStream.ToArray();
*/
                        await dbContext.Products.AddAsync(newProduct);

                        StockWithProduct stockProduct = new StockWithProduct
                        {
                            stockId = vm.stock.skuId,
                            propductId = newProduct.productId
                        };

                        await dbContext.StockProducts.AddAsync(stockProduct);
                    }
                }
            }
            await dbContext.SaveChangesAsync();
            return vm;
        }

        public async Task<StockViewModel> StockDetailsAsync(Guid skuId)
        {
            var stock = await dbContext.Stocks.SingleOrDefaultAsync(x => x.skuId == skuId);
            var productsList = new List<StockProductDto>();
            var response = await dbContext.StockProducts
                .Where(x => x.stockId == skuId)
                .ToListAsync();
            if (response != null)
            {
                foreach (var res in response)
                {
                    var product = await dbContext.Products
                        .Where(x => x.productId == res.propductId)
                        .FirstOrDefaultAsync();
                    if (product != null)
                    {
                        productsList.Add(new StockProductDto
                        {
                            productName = product.productName,
                            productDesc = product.productDesc,
                            //ProductViewPicture = Convert.ToBase64String(product.productImageByteString),
                            //ProductViewPictureFormat = product.productImage,
                            productQuantity = product.productQuantity,
                            productUnitPrice = product.productUnitPrice,
                            categoryId = product.categoryId
                        });
                    }
                }
            }
            var vm = new StockViewModel
            {
                products = productsList
            };
            if (stock != null)
            {
                vm.stock = stock;
            }
            return vm;
        }

        public Task<Stock> UpdateStockAsync(Guid skuId)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> UpdateStockAsync(Stock stock)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> RemoveStockAsync(Guid stockId)
        {
            throw new NotImplementedException();
        }
    }
}
