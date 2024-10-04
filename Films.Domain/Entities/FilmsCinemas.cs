namespace Films.Core.Domain.Entities;

public class FilmsCinemas
{
    public Guid FilmId { get; set; }
    public Guid CinemaId { get; set; }

    // Navigation properties
    public Film Film { get; set; }
    public Cinema Cinema { get; set; }
}
