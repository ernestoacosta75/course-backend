using AutoMapper;
using Films.Core.Application.Models;
using Films.Core.Domain.Entities;

namespace course_backend.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<GenderCreationDto, Gender>().ReverseMap();
        }
    }
}
