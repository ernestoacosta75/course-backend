using Films.Core.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Films.Core.Domain.Entities
{
    public class Gender
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(maximumLength: 10)]
        [FirstLetterUppercase]
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public List<FilmsGenders> FilmsGenders { get; set; } = [];
    }
}
