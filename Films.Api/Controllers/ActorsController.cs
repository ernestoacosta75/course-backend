using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Dtos;
using Films.Core.Application.Services.Actor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
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
        public ActionResult Post([FromForm] ActorCreationDto actorCreationDto)
        {
            _actorService.AddActor(actorCreationDto);
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ActorDto actorDto)
        {
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
