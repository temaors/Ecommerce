using AutoMapper;
using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;

namespace eCommerce.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ApiProductInfo>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src =>src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src =>src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src =>src.Price))
            .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src =>src.SubCategoryId))
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src =>src.Unit))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src =>src.Rating))
            .ForMember(dest => dest.Reference, opt => opt.MapFrom(src =>src.Reference))
            .ReverseMap();
    }
}