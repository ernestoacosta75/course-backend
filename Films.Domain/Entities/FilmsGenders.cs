namespace Films.Core.Domain.Entities;

public class FilmsGenders
{
    public Guid FilmId { get; set; }
    public Guid GenderId { get; set; }

    // Navigation properties
    public Film Film { get; set; }
    public Gender Gender { get; set; }
}
