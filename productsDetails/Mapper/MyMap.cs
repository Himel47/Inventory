using AutoMapper;
using productsDetails.DTOs;
using productsDetails.Models;

namespace productsDetails.Mapper
{
    public class MyMap:Profile
    {
        public MyMap()
        {
            CreateMap<Product, StockProductDto>();
            CreateMap<StockProductDto, Product>();
        }
    }
}
