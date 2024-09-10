using AutoMapper;
using Inventory.AggregateRoot.IMapping;
using Inventory.AggregateRoot.Models;
using Inventory.DTO.DTOs;
using Inventory.DTO.ViewModels;
using Inventory.Handler.IServices;
using Inventory.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Handler.Services
{
    public class StockHandler : IStockHandler
    {
        private readonly IGenericRepository<Stock> _genericStockRepository;
        private readonly IGenericRepository<StockWithProduct> _genericStockProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMappingOperations _operation;
        private readonly IMapper _mapper;

        public StockHandler(IGenericRepository<Stock> stockRepository,
                            IGenericRepository<StockWithProduct> stockProductRepository,
                            IProductRepository productRepository,
                            IMappingOperations operation,
                            IMapper mapper)
        {
            _genericStockRepository = stockRepository;
            _genericStockProductRepository = stockProductRepository;
            _productRepository = productRepository;
            _operation = operation;
            _mapper = mapper;
        }

        public async Task<List<Stock>> GetStocksAsync()
        {
            return await _genericStockRepository.GetAllAsync();
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
            await _genericStockRepository.AddAsync(st);
            await _genericStockRepository.SaveDbChanges();
            return st;
        }

        public async Task<StockViewModel> AddProductsToStockAsync(StockDto st)
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
            var stock = await _genericStockRepository.GetByIdAsync(vm.stock.skuId);
            if (vm.products != null && vm.products.Count != 0)
            {
                foreach (var product in vm.products)
                {
                    // stock and product relation
                    var stockWithProduct = new StockWithProduct
                    {
                        stockId = vm.stock.skuId,
                        productStockPrice = product.productUnitPrice,
                        productStockQuantity = product.productQuantity,
                    };
                    var existedProduct = await _productRepository.GetExistingStockProduct(product);

                    if (existedProduct != null)
                    {
                        existedProduct.productQuantity += product.productQuantity;
                        stockWithProduct.propductId = existedProduct.productId;
                    }
                    else
                    {
                        var newProduct = _mapper.Map<Product>(product);
                        await _productRepository.AddAsync(newProduct);
                        stockWithProduct.propductId = newProduct.productId;
                    }
                    await _genericStockProductRepository.AddAsync(stockWithProduct);
                    stock.StockTotalCost += product.productQuantity * product.productUnitPrice;
                    await _productRepository.SaveDbChanges();
                }
            }
            return vm;
        }

        public async Task<StockViewModel> StockDetailsAsync(Guid skuId)
        {
            var stock = await _genericStockRepository.GetByIdAsync(skuId);
            var productsList = new List<StockProductDto>();
            var productsIdsInThisStock = await _productRepository.GetStockProductsAsync(stock.skuId);
            if (productsIdsInThisStock != null)
            {
                foreach (var stockProduct in productsIdsInThisStock)
                {
                    var product = await _productRepository.GetByIdAsync(stockProduct.propductId);
                    if (product != null)
                    {
                        var newStockProduct = _mapper.Map<StockProductDto>(product);
                        newStockProduct.productQuantity = stockProduct.productStockQuantity;
                        newStockProduct.productUnitPrice = stockProduct.productStockPrice;
                        productsList.Add(newStockProduct);
                    }
                }
            }
            var vm = new StockViewModel
            {
                products = productsList,
                stock = stock
            };
            return vm;
        }
    }
}
