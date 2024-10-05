using Films.Core.Application.Dtos.Film;

namespace Films.Core.Application.Services.Film
{
    public interface IFimService
    {
        void AddFilm(FilmCreationDto filmCreationDto);
        Task UpdateFilm(FilmDto filmDto);
        Task RemoveFilm(FilmDto filmDto);
        Task<FilmDto?> GetFilmById(Guid filmId);
        IQueryable<FilmDto> GetAllFilms();
    }
}
