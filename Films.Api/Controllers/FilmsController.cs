using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Dtos;
using Films.Core.Application.Dtos.Film;
using Films.Core.Application.Services.Archives;
using Films.Core.Application.Services.Film;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFimService _filmService;
    private readonly ILocalArchiveStorageService _localArchiveStorageService;
    private readonly string container = "films";
    public FilmsController(IFimService filmService, ILocalArchiveStorageService localArchiveStorageService)
    {
        _filmService = filmService;
        _localArchiveStorageService = localArchiveStorageService;
    }

    [HttpGet]
    public async Task<ActionResult<List<FilmDto>>> GetAllFilms([FromQuery] PaginationDto paginationDto)
    {
        ArgumentNullException.ThrowIfNull(paginationDto, nameof(paginationDto));

        var queryable = _filmService.GetAllFilms();
        await HttpContext.InsertPaginationParametersInHeader(queryable);
        var films = await queryable
            .OrderBy(x => x.Title)
            .Paginate(paginationDto)
            .ToListAsync();

        return films;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<FilmDto>> GetCinemaById(Guid id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        FilmDto? film = await _filmService.GetFilmById(id);

        if (film == null)
        {
            return NotFound();
        }

        return film;
    }

    //[HttpPost]
    //public ActionResult Post([FromForm] FilmCreationDto filmCreationDto)
    //{
    //    ArgumentNullException.ThrowIfNull(filmCreationDto, nameof(filmCreationDto));

    //    _filmService.AddFilm(filmCreationDto);

    //    return NoContent();
    //}

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] FilmDto filmDto)
    {
        var film = await _filmService.GetFilmById(filmDto.Id);

        if (film == null)
        {
            return NotFound();
        }

        await _filmService.UpdateFilm(filmDto);

        return NoContent();
    }
}
