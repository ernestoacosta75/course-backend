using System.ComponentModel.DataAnnotations;

namespace Films.Core.Application.Dtos
{
    public abstract class ActorBaseDto
    {        
        [Required]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
    }
}
