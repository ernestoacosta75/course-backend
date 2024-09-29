using Films.Api.Utilities;
using Films.Core.Application.Dtos;
using Films.Core.Application.Services.Cinema;
using Microsoft.AspNetCore.Mvc;

namespace Films.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CinemasController : ControllerBase
{
    private readonly ICinemaService _cinemaService;

    public CinemasController(ICinemaService cinemaService)
    {
        _cinemaService = cinemaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CinemaDto>>> GetAllCinemas([FromQuery] PaginationDto paginationDto)
    {
        ArgumentNullException.ThrowIfNull(paginationDto, nameof(paginationDto));

        var queryable = _cinemaService.GetAllCinemas();
        await HttpContext.InsertPaginationParametersInHeader(queryable);
        var cinemas = await queryable
            .OrderBy(x => x.Name)
            .Paginate(paginationDto)
            .ToListAsync();

        return cinemas;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<CinemaDto>> GetCinemaById(Guid id)
    {
        CinemaDto? cinema = await _cinemaService.GetCinemaById(id);

        if (cinema == null)
        {
            return NotFound();
        }

        return cinema;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromForm] CinemaCreationDto cinemaCreationDto)
    {
        ArgumentNullException.ThrowIfNull(cinemaCreationDto, nameof(cinemaCreationDto));

        _cinemaService.AddCinema(cinemaCreationDto);

        return NoContent();
    }
}
