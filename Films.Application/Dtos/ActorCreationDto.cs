using Microsoft.AspNetCore.Http;

namespace Films.Core.Application.Dtos
{
    public class ActorCreationDto : ActorBaseDto
    {
        public IFormFile Picture { get; set; }
    }
}
