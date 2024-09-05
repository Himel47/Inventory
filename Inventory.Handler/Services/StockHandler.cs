using Inventory.AggregateRoot;
using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Handler.IServices;
using Inventory.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Handler.Services
{
    public class StockHandler : IStockHandler
    {
        private readonly IGenericRepository<Stock> _stockRepository;
        private readonly IGenericRepository<StockWithProduct> _stockProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOperations _operation;

        public StockHandler(IGenericRepository<Stock> stockRepository,
                            IProductRepository productRepository,
                            IGenericRepository<StockWithProduct> stockProductRepository,
                            IOperations operation)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
            _stockProductRepository = stockProductRepository;
            _operation = operation;
        }

        public async Task<List<Stock>> GetStocksAsync()
        {
            return await _stockRepository.GetAllAsync();
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
            await _stockRepository.AddAsync(st);
            return st;
        }

        public async Task<StockViewModel> AddProductsToStockAsync(Stock st)
        {
            var categories = await _operation.GetCategories();
            var vm = new StockViewModel
            {
                stock = st,
                products = Enumerable.Range(0, st.ProductNumber)
                    .Select(i => new StockProductDto())
                    .ToList(),
                Categories = new SelectList(categories.Select(c => new { Value = (int)c, Text = c.ToString() }), "Value", "Text")
            };

            return vm;
        }

        public async Task<StockViewModel> AddProductsToStockAsync(StockViewModel vm)
        {
            var stock = await _stockRepository.GetByIdAsync(vm.stock.skuId);
            if (vm.products != null && vm.products.Count != 0)
            {
                foreach (var product in vm.products)
                {
                    var existedProduct = await _productRepository.GetExistingStockProduct(product);
                    if (existedProduct != null)
                    {
                        existedProduct.productQuantity += product.productQuantity;
                        await _productRepository.SaveDbChanges();
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

                        await _productRepository.AddAsync(newProduct);

                        await _stockProductRepository.AddAsync(new StockWithProduct
                        {
                            stockId = vm.stock.skuId,
                            propductId = newProduct.productId
                        });
                    }
                    stock.StockTotalCost += product.productQuantity * product.productUnitPrice;
                }
            }
            return vm;
        }

        public async Task<StockViewModel> StockDetailsAsync(Guid skuId)
        {
            var stock = await _stockRepository.GetByIdAsync(skuId);
            var productsList = new List<StockProductDto>();
            var productsIdsInThisStock = await _productRepository.GetStockProductsAsync(stock.skuId);
            if (productsIdsInThisStock != null)
            {
                foreach (var stockProduct in productsIdsInThisStock)
                {
                    var product = await _productRepository.GetByIdAsync(stockProduct.propductId);
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
    }
}
