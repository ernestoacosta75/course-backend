using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace Films.Core.Domain.Entities;

public class Cinema
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(maximumLength: 75)]
    public string Name { get; set; } = string.Empty;
    public Point Location { get; set; }

    // Navigation properties
    public List<FilmsCinemas> FilmsCinemas { get; set; } = [];
}
