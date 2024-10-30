using System.ComponentModel.DataAnnotations;
using Films.Core.Domain.Validations;

namespace Films.Core.Application.Dtos.Category;

public class CategoryCreationDto
{
    [Required]
    [StringLength(maximumLength: 10)]
    [FirstLetterUppercase]
    public string Name { get; set; } = string.Empty;
}
