namespace Films.Core.Domain.Entities;

public class FilmsCategories
{
    public Guid FilmId { get; set; }
    public Guid CategoryId { get; set; }

    // Navigation properties
    public Film Film { get; set; }
    public Category Category { get; set; }
}
