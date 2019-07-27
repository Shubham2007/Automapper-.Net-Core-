using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace AutomapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Simple Mapping
            CreateMap<UserDto, User>();
            //CreateMap<User, UserDto>();  //or use ReverseMap() on above function to swap source and destination

            //Complex Mapping With Different Name Properties
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Firstname))
                .ReverseMap();

        }
    }
}
