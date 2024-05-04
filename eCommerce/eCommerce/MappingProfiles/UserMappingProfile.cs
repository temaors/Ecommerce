using AutoMapper;
using eCommerce.APIObjects;
using eCommerce.Database.DbEntities;

namespace eCommerce.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {			
        CreateMap<User, ApiUser>().ReverseMap();
    }
}