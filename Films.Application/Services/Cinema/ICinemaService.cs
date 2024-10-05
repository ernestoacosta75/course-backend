using Films.Core.Application.Dtos.Cinema;

namespace Films.Core.Application.Services.Cinema
{
    public interface ICinemaService
    {
        void AddCinema(CinemaCreationDto cinema);
        Task UpdateCinema(CinemaDto cinemaDto);
        Task RemoveCinema(CinemaDto cinemaDto);
        Task<CinemaDto?> GetCinemaById(Guid cinemaId);
        IQueryable<CinemaDto> GetAllCinemas();
    }
}
