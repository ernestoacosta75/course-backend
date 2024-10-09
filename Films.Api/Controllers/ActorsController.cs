using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Dtos;
using Films.Core.Application.Dtos.Actor;
using Films.Core.Application.Dtos.Film;
using Films.Core.Application.Services.Actor;
using Films.Core.Application.Services.Archives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorsController : ControllerBase
{
    private readonly IActorService _actorService;
    private readonly ILocalArchiveStorageService _localArchiveStorageService;
    private readonly string container = "actors";

    public ActorsController(IActorService actorService, 
        ILocalArchiveStorageService localArchiveStorageService)
    {
        _actorService = actorService;
        _localArchiveStorageService = localArchiveStorageService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ActorDto>>> GetAllActors([FromQuery] PaginationDto paginationDto)
    {
        if (paginationDto is null)
        {
            throw new ArgumentNullException(nameof(paginationDto));
        }

        var queryable = _actorService.GetAllActors();
        await HttpContext.InsertPaginationParametersInHeader(queryable);
        var actors = await queryable
            .OrderBy(x => x.Name)
            .Paginate(paginationDto)
            .ToListAsync();

        return actors;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<ActorDto>> GetActorById(Guid id)
    {
        ActorDto? actor = await _actorService.GetActorById(id);

        if (actor == null)
        {
            return NotFound();
        }

        return actor;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromForm] ActorCreationDto actorCreationDto)
    {
        ArgumentNullException.ThrowIfNull(actorCreationDto, nameof(actorCreationDto));

        string pictureUrl = string.Empty;
        
        if (actorCreationDto.Picture != null)
        {
            pictureUrl = await _localArchiveStorageService.SaveArchive(container, actorCreationDto.Picture);
        }

        _actorService.AddActor(new ActorDto
        {
            Biography = actorCreationDto.Biography,
            DateOfBirth = actorCreationDto.DateOfBirth,
            Name = actorCreationDto.Name,
            Picture = pictureUrl
        });

        return NoContent();
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(Guid id, [FromForm] ActorCreationDto actorCreationDto)
    {
        ArgumentNullException.ThrowIfNull(actorCreationDto, nameof(actorCreationDto));

        var actorDto = await _actorService.GetActorToUpdateById(id);

        if (actorDto == null)
        {
            return NotFound();
        }

        await _actorService.UpdateActor(id, actorCreationDto);

        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var actorDto = await _actorService.GetActorById(id);

        if (actorDto == null)
        {
            return NotFound();
        }

        await _actorService.RemoveActor(actorDto);
        await _localArchiveStorageService.RemoveArchive(actorDto.Picture, container);

        return NoContent();
    }
}
