using Films.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Films.Domain.Entities
{
    public class Gender
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(maximumLength: 10)]
        [FirstLetterUppercase]
        public string Name { get; set; } = string.Empty;
    }
}
