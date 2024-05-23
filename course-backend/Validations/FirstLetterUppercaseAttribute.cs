using System.ComponentModel.DataAnnotations;

namespace course_backend.Validations;

public class FirstLetterUppercaseAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }

        var firstLetter = value.ToString()[0].ToString();
        
        if (firstLetter != firstLetter.ToUpper())
        {
            return new ValidationResult("The first letter must be uppercase");
        }

        return ValidationResult.Success;
    }
}
