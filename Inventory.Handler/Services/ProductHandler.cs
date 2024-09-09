using Inventory.DTO.DTOs;
using Inventory.DTO.Models;
using Inventory.DTO.ViewModels;
using Inventory.Repository.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inventory.Repository.IRepository;
using AutoMapper;
using Inventory.AggregateRoot.IMapping;

namespace Inventory.Repository.Services
{
    public class ProductHandler : IProductsHandler
    {
        private readonly IGenericRepository<Product> _genericProductRepository;
        private readonly IMapper _mapper;
        private readonly IMappingOperations _operations;
        private readonly IProductRepository _productRepository;

        public ProductHandler(IGenericRepository<Product> genericRepository,
                              IMapper mapper,
                              IMappingOperations operations,
                              IProductRepository productRepository)
        {
            _genericProductRepository = genericRepository;
            _mapper = mapper;
            _operations = operations;
            _productRepository = productRepository;
        }

        public async Task<AddProductViewModel> AddProductAsync()
        {
            var categories = await _operations.GetCategories();

            var vm = new AddProductViewModel
            {
                Categories = new SelectList(categories.Select(c => new { Value = (int)c, Text = c.ToString() }), "Value", "Text")
            };
            return vm;
        }

        public Task<Product> AddProductAsync(StockProductDto product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StockProductDto>> GetProductsAsync()
        {
            List<StockProductDto> products = new List<StockProductDto>();
            var allProducts = await _genericProductRepository.GetAllAsync();
            if (allProducts != null)
            {
                foreach(var product in allProducts)
                {
                    var singleProduct = _mapper.Map<StockProductDto>(product);
                    products.Add(singleProduct);
                }
            }
            return products;
        }

        public async Task<Product> ProductDetailsAsync(string productName, int categoryId)
        {
            var product = await _productRepository.GetProductByName(productName,categoryId);

            return null;
        }
    }
}
