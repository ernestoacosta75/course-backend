using System.ComponentModel.DataAnnotations;

namespace Films.Core.Domain.Entities;

public class FilmsActors
{
    public Guid FilmId { get; set; }
    public Guid ActorId { get; set; }

    // Navigation properties
    public Film Film { get; set; }
    public Actor Actor { get; set; }

    // Extra properties
    // We need to save the character interpreted by the actor too
    [StringLength(maximumLength: 100)]
    public string Character { get; set; }
    public int Order { get; set; }
}
