using System.ComponentModel.DataAnnotations;

namespace Films.Core.Application.Dtos
{
    public class ActorCreationDto : ActorBaseDto
    {
        public Guid Id { get; set; }
    }
}
