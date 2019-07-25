using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace AutomapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
