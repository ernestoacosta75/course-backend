using System.ComponentModel.DataAnnotations;

namespace Films.Core.Domain.Entities;

public class Film
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(maximumLength: 300)]
    public string Title { get; set; } = string.Empty;
    public string Resume { get; set; } = string.Empty;
    public string Trailer { get; set; } = string.Empty;
    public bool OnCinemas { get; set; } = false;
    public DateTime ReleaseDate { get; set; }

    // Navigation properties
    public List<FilmsActors> FilmsActors { get; set; } = [];
    public List<FilmsGenders> FilmsGenders { get; set; } = [];
    public List<FilmsCinemas> FilmsCinemas { get; set; } = [];
}
