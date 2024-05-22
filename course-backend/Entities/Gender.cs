using course_backend.Validations;
using System.ComponentModel.DataAnnotations;

namespace course_backend.Entities;

public class Gender : IValidatableObject
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(maximumLength: 10)]
    //[FirstLetterUppercase]
    public string Name { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(Name))
        {
            var firstLetter = Name[0].ToString();

            if (firstLetter != firstLetter.ToUpper())
            {
                yield return new ValidationResult("The first letter must be uppercase",
                    new string[] { nameof(Name) });
            }
        }
    }
}
