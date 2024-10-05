using System.ComponentModel.DataAnnotations;

namespace Films.Core.Application.Dtos.Film;

public abstract class FilmBaseDto
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(maximumLength: 300)]
    public string Title { get; set; } = string.Empty;
    public string Resume { get; set; } = string.Empty;
    public string Trailer { get; set; } = string.Empty;
    public bool OnCinemas { get; set; } = false;
    public DateTime ReleaseDate { get; set; }
    public string Poster { get; set; } = string.Empty;
}
