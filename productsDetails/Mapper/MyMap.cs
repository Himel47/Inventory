using AutoMapper;
using Inventory.DTO.DTOs;
using Inventory.DTO.Models;

namespace Inventory.Mapper
{
    public class MyMap : Profile
    {
        private byte[] ConvertStreamToByteArray(IFormFile formFile)
        {
            var mStream = new MemoryStream();
            formFile.CopyTo(mStream);
            return mStream.ToArray();
        }
        public MyMap()
        {
            CreateMap<Product, StockProductDto>()
                .ForMember(destination => destination.ProductViewPicture,
                        begin => begin.MapFrom(mappingSrc => Convert.ToBase64String(mappingSrc.productImageByteString)))
                .ForMember(destination => destination.ProductViewPictureFormat,
                        begin => begin.MapFrom(mappingSrc => mappingSrc.productImage));
            CreateMap<StockProductDto, Product>()
                .ForMember(destination => destination.productImage,
                        begin => begin.MapFrom(src => src.productImageInput.ContentType))
                .ForMember(destination => destination.productImageByteString,
                        begin => begin.MapFrom(src => ConvertStreamToByteArray(src.productImageInput)));
        }
    }
}
