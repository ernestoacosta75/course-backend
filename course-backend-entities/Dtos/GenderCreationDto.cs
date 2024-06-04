using System.ComponentModel.DataAnnotations;

namespace course_backend_entities.Dtos
{
    public class GenderCreationDto
    {
        [Required]
        [StringLength(maximumLength: 10)]
        [FirstLetterUppercase]
        public string Name { get; set; }
    }
}
