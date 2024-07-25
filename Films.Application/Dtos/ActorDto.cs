using System.ComponentModel.DataAnnotations;

namespace Films.Core.Application.Dtos
{
    public class ActorDto : ActorBaseDto
    {
        public string Picture { get; set; } = string.Empty;
    }
}
