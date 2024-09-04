using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Handler.IServices;
using Inventory.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Handler.Services
{
    public class StockHandler : IStockHandler
    {
        private readonly IStockRepository stockRepository;
        private readonly IProductRepository productRepository;

        public StockHandler(IStockRepository _stockRepository, IProductRepository _productRepository)
        {
            stockRepository = _stockRepository;
            productRepository = _productRepository;
        }

        public async Task<List<Stock>> GetStocksAsync()
        {
            var allStocks = await stockRepository.GetAllStocks();
            return allStocks;
        }

        public async Task<Stock> AddStockAsync()
        {
            return new Stock
            {
                StockReceiveDate = DateTime.Today
            };
        }

        public async Task<Stock> AddStockAsync(Stock st)
        {
            var boolResponse = await stockRepository.AddStockAsync(st);
            if (boolResponse)
            {
                await stockRepository.SaveDbChanges();
            }

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
            var stock = await stockRepository.GetStockById(vm.stock.skuId);
            if (vm.products != null && vm.products.Count != 0)
            {
                foreach (var product in vm.products)
                {
                    var existedProduct = await productRepository.GetExistingStockProduct(product);
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
                            productImage = product.productImage.ContentType,
                            productStatus = "In Stock",
                            productQuantity = product.productQuantity,
                            productUnitPrice = product.productUnitPrice,
                            categoryId = product.categoryId
                        };

                        var mStream = new MemoryStream();
                        product.productImage.CopyTo(mStream);
                        newProduct.productImageByteString = mStream.ToArray();

                        await productRepository.AddProductAsync(newProduct);

                        await productRepository.AddStockProductAsync(new StockWithProduct
                        {
                            stockId = vm.stock.skuId,
                            propductId = newProduct.productId
                        });
                    }
                    stock.StockTotalCost += product.productQuantity * product.productUnitPrice;
                }
            }
            await stockRepository.SaveDbChanges();
            return vm;
        }

        public async Task<StockViewModel> StockDetailsAsync(Guid skuId)
        {
            var stock = await stockRepository.GetStockById(skuId);
            var productsList = new List<StockProductDto>();
            var productsIdsInThisStock = await productRepository.GetStockProductsAsync(skuId);
            if (productsIdsInThisStock != null)
            {
                foreach (var stockProduct in productsIdsInThisStock)
                {
                    var product = await productRepository.GetProductByIdAsync(stockProduct.propductId);
                    if (product != null)
                    {
                        productsList.Add(new StockProductDto
                        {
                            productName = product.productName,
                            productDesc = product.productDesc,
                            ProductViewPicture = Convert.ToBase64String(product.productImageByteString),
                            ProductViewPictureFormat = product.productImage,
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
