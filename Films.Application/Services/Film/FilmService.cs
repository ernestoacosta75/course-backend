using AutoMapper;
using Films.Core.Application.Dtos.Film;
using Films.Core.Application.Services.Archives;
using Films.Core.Domain.Entities;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.Attributes;

namespace Films.Core.Application.Services.Film;

public class FilmService : IFimService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILocalArchiveStorageService _localArchiveStorageService;
    private readonly string container = "films";

    public FilmService(IUnitOfWork unitOfWork,
                       IMapper mapper,
                       ILocalArchiveStorageService localArchiveStorageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _localArchiveStorageService = localArchiveStorageService;
    }

    [Log]
    public async void AddFilm(FilmCreationDto filmCreationDto)
    {
        string pictureUrl = string.Empty;
        var film = _mapper.Map<Domain.Entities.Film>(filmCreationDto);

        if (filmCreationDto.Poster != null)
        {
            pictureUrl = await _localArchiveStorageService.SaveArchive(container, filmCreationDto.Poster);
        }

        WriteActorsOrden(film);

        _unitOfWork.FilmRepository.Add(film);
        _unitOfWork.Save();
    }

    [Log]
    public IQueryable<FilmDto> GetAllFilms()
    {
        var films = _unitOfWork.FilmRepository.GetAll();
        var filmDtos = _mapper.ProjectTo<FilmDto>(films);

        return filmDtos;
    }

    [Log]
    public async Task<FilmDto?> GetFilmById(Guid filmId)
    {
        var film = await _unitOfWork.FilmRepository.GetById(filmId);
        return _mapper.Map<FilmDto>(film);
    }

    [Log]
    public async Task RemoveFilm(FilmDto filmDto)
    {
        var filmToDelete = await _unitOfWork.FilmRepository.GetById(filmDto.Id);

        if (filmToDelete != null)
        {
            _unitOfWork.FilmRepository.Delete(filmToDelete);
            await _unitOfWork.SaveAsync();
        }
    }

    [Log]
    public async Task UpdateFilm(FilmDto filmDto)
    {
        var existingFilm = await _unitOfWork.FilmRepository.GetById(filmDto.Id);

        if (existingFilm != null)
        {
            _mapper.Map(filmDto, existingFilm);

            // Save the updated entity
            _unitOfWork.FilmRepository.Update(existingFilm);
            await _unitOfWork.SaveAsync();
        }
    }

    private void WriteActorsOrden(Domain.Entities.Film film)
    {
        if (film.FilmsActors != null)
        {
            for (int i = 0; i < film.FilmsActors.Count; i++)
            {
                film.FilmsActors[i].Order = i;
            }
        } 
    }
}
