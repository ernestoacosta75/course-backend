using Films.Core.Application.Dtos.NavigationProperties;
using Films.Core.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Films.Core.Application.Dtos.Film;

public class FilmCreationDto : FilmBaseDto
{
    public IFormFile Poster { get; set; }
    [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
    public List<Guid> GenderIds { get; set; } = [];
    [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
    public List<Guid> CinemaIds { get; set; } = [];
    [ModelBinder(BinderType = typeof(TypeBinder<List<ActorFilmCreationDto>>))]
    public List<ActorFilmCreationDto> Actors { get; set; } = [];
}
