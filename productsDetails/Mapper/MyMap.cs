using AutoMapper;
using Inventory.DTO.DTOs;
using Inventory.DTO.Models;

namespace Inventory.Mapper
{
    public class MyMap : Profile
    {
        public MyMap()
        {
            CreateMap<Product, StockProductDto>()
                .ForMember(destination=>destination.ProductViewPicture, begin=> begin.MapFrom(mappingSrc=>Convert.ToBase64String(mappingSrc.productImageByteString)))
                .ForMember(destination=>destination.ProductViewPictureFormat, begin=> begin.MapFrom(mappingSrc=> mappingSrc.productImage));
            CreateMap<StockProductDto, Product>();
        }
    }
}
