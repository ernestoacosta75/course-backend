using course_backend.Validations;
using System.ComponentModel.DataAnnotations;

namespace course_backend.Entities;

public class Gender
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(maximumLength: 10)]
    [FirstLetterUppercase]
    public string Name { get; set; }
}
