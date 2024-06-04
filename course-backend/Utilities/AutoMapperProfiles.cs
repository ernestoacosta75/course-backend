using AutoMapper;
using course_backend_entities.Dtos;
using course_backend_entities;

namespace course_backend.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<GenderCreationDto, Gender>();
        }
    }
}
