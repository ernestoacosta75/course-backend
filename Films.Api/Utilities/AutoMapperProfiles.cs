using AutoMapper;
using Films.Core.Application.Dtos.Actor;
using Films.Core.Application.Dtos.Cinema;
using Films.Core.Application.Dtos.Film;
using Films.Core.Application.Dtos.Gender;
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

            CreateMap<Film, FilmDto>().ReverseMap();

            CreateMap<FilmCreationDto, Film>()
                .ForMember(m => m.Poster, options => options.Ignore())
                .ForMember(m => m.FilmsGenders, options => options.MapFrom(FilmsGendersMap))
                .ForMember(m => m.FilmsCinemas, options => options.MapFrom(FilmsCinemasMap))
                .ForMember(m => m.FilmsActors, options => options.MapFrom(FilmsActorsMap))
                .ReverseMap();
        }

        private List<FilmsGenders> FilmsGendersMap(FilmCreationDto filmCreationDto, Film film)
        {
            var result = new List<FilmsGenders>();

            if (filmCreationDto.GenderIds == null)
            {
                return result;
            }

            foreach (var genderId in filmCreationDto.GenderIds)
            {
                result.Add(new FilmsGenders
                {
                    GenderId = genderId
                });
            }

            return result;
        }

        private List<FilmsCinemas> FilmsCinemasMap(FilmCreationDto filmCreationDto, Film film)
        {
            var result = new List<FilmsCinemas>();

            if (filmCreationDto.CinemaIds == null)
            {
                return result;
            }

            foreach (var cinemaId in filmCreationDto.CinemaIds)
            {
                result.Add(new FilmsCinemas
                {
                    CinemaId = cinemaId
                });
            }

            return result;
        }

        private List<FilmsActors> FilmsActorsMap(FilmCreationDto filmCreationDto, Film film)
        {
            var result = new List<FilmsActors>();

            if (filmCreationDto.Actors == null)
            {
                return result;
            }

            foreach (var actor in filmCreationDto.Actors)
            {
                result.Add(new FilmsActors
                {
                    ActorId = actor.Id,
                    Character = actor.Character
                });
            }

            return result;
        }
    }
}
