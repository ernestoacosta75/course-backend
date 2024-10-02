using AutoMapper;
using Films.Core.Application.Dtos;
using Films.Core.Domain.Entities;
using NetTopologySuite.Geometries;

namespace course_backend.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<GenderCreationDto, Gender>().ReverseMap();
            CreateMap<Actor, ActorDto>().ReverseMap();
            CreateMap<ActorCreationDto, Actor>()
                .ForMember(m => m.Picture, options => options.Ignore());

            CreateMap<CinemaCreationDto, Cinema>()
                .ForMember(c => c.Location, 
                c => c.MapFrom(dto => geometryFactory
                .CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))))
                .ReverseMap();

            CreateMap<CinemaDto, Cinema>()
            .ForMember(c => c.Location, c => c.MapFrom(dto =>
                geometryFactory.CreatePoint(new Coordinate(dto.Longitude, dto.Latitude))))
            .ReverseMap()
            // Map Latitude and Longitude from the Location property
            .ForMember(dto => dto.Latitude, c => c.MapFrom(cinema => cinema.Location.Y))
            .ForMember(dto => dto.Longitude, c => c.MapFrom(cinema => cinema.Location.X));
        }
    }
}
