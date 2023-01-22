using AutoMapper;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.BrandDtos;
using Zay.Entities.DTOs.CategoryDtos;
using Zay.Entities.DTOs.ColorDtos;
using Zay.Entities.DTOs.DiscountDtos;
using Zay.Entities.DTOs.SizeDtos;
using Zay.Entities.DTOs.SpesificationDtos;

namespace Zay.Utilities.Profiles.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<SizePostDto, Size>();
            CreateMap<SizeGetDto, Size>().ReverseMap();
            //CreateMap<List<Size>, List<SizeGetDto>>();

            CreateMap<ColorPostDto, Color>();
            CreateMap<ColorGetDto, Color>().ReverseMap();

            CreateMap<DiscountPostDto, Discount>();
            CreateMap<DiscountGetDto, Discount>().ReverseMap();

            CreateMap<BrandPostDto, Brand>();
            CreateMap<BrandGetDto, Brand>().ReverseMap();

            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryGetDto, Category>().ReverseMap();

            CreateMap<SpesificationPostDto, ProductSpesification>();
            CreateMap<SpesificationGetDto, ProductSpesification>().ReverseMap();

            CreateMap<SpesificationGetDto, ProductSpesification>().ReverseMap();
        }
    }
}
