using AutoMapper;
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
        private readonly IMapper _mapper;

        public StockHandler(IGenericRepository<Stock> stockRepository,
                            IProductRepository productRepository,
                            IGenericRepository<StockWithProduct> stockProductRepository,
                            IOperations operation,
                            IMapper mapper)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
            _stockProductRepository = stockProductRepository;
            _operation = operation;
            _mapper = mapper;
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
                    await _stockProductRepository.AddAsync(stockWithProduct);
                    stock.StockTotalCost += product.productQuantity * product.productUnitPrice;
                    await _productRepository.SaveDbChanges();
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
                        var newStockProduct = _mapper.Map<StockProductDto>(product);
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
