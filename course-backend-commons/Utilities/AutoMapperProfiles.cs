using AutoMapper;
using course_backend_entities;
using course_backend_entities.Dtos;

namespace course_backend_commons.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
        }
    }
}
