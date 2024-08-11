using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Dtos;
using Films.Core.Application.Services.Actor;
using Films.Core.Application.Services.Archives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Api.Controllers
{
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
            if (actorCreationDto is null)
            {
                throw new ArgumentNullException(nameof(actorCreationDto));
            }

            if (actorCreationDto.Picture != null)
            {
                await _localArchiveStorageService.SaveArchive(container, actorCreationDto.Picture);
            }

            _actorService.AddActor(actorCreationDto);
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActorDto actorDto)
        {
            if (actorDto is null)
            {
                throw new ArgumentNullException(nameof(actorDto));
            }

            var actor = await _actorService.GetActorToUpdateById(id);

            if (actor == null)
            {
                return NotFound();
            }

            actorDto.Id = id;
            actorDto.Id = id;
            await _actorService.UpdateActor(actorDto);

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var actor = await _actorService.GetActorById(id);

            if (actor == null)
            {
                return NotFound();
            }

            await _actorService.RemoveActor(actor);

            return NoContent();
        }
    }
}
