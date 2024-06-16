using Films.Core.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Films.Core.Application.Models
{
    public class GenderCreationDto
    {
        [Required]
        [StringLength(maximumLength: 10)]
        [FirstLetterUppercase]
        public string Name { get; set; } = string.Empty;
    }
}
