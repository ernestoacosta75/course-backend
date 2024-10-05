using AutoMapper;
using Films.Core.Application.Dtos.Cinema;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.Attributes;

namespace Films.Core.Application.Services.Cinema;

public class CinemaService : ICinemaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CinemaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Log]
    public void AddCinema(CinemaCreationDto cinemaCreationDto)
    {
        _unitOfWork.CinemaRepository.Add(_mapper.Map<Domain.Entities.Cinema>(cinemaCreationDto));
        _unitOfWork.Save();
    }

    [Log]
    public IQueryable<CinemaDto> GetAllCinemas()
    {
        var cinemas = _unitOfWork.CinemaRepository.GetAll();
        var cinemaDtos = _mapper.ProjectTo<CinemaDto>(cinemas);

        return cinemaDtos;
    }

    [Log]
    public async Task<CinemaDto?> GetCinemaById(Guid cinemaId)
    {
        var cinema = await _unitOfWork.CinemaRepository.GetById(cinemaId);
        return _mapper.Map<CinemaDto>(cinema);
    }

    [Log]
    public async Task RemoveCinema(CinemaDto cinemaDto)
    {
        var cinemaToDelete = _unitOfWork.CinemaRepository.GetById(cinemaDto.Id).Result;

        if (cinemaToDelete != null)
        {
            _unitOfWork.CinemaRepository.Delete(cinemaToDelete);
            await _unitOfWork.SaveAsync();
        }
    }

    [Log]
    public async Task UpdateCinema(CinemaDto cinemaDto)
    {
        var existingCinema = await _unitOfWork.CinemaRepository.GetById(cinemaDto.Id);

        if (existingCinema != null)
        {
            _mapper.Map(cinemaDto, existingCinema);

            // Save the updated entity
            _unitOfWork.CinemaRepository.Update(existingCinema);
            await _unitOfWork.SaveAsync();
        }
    }
}
