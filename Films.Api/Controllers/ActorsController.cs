using Films.Core.Application.Services.Actor;
using Microsoft.AspNetCore.Mvc;

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
    }
}
