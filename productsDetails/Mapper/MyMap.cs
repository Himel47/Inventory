using AutoMapper;
using Inventory.DTO.DTOs;
using Inventory.DTO.Models;

namespace Inventory.Mapper
{
    public class MyMap : Profile
    {
        public MyMap()
        {
            CreateMap<Product, StockProductDto>();
            CreateMap<StockProductDto, Product>();
        }
    }
}
