using System.ComponentModel.DataAnnotations;

namespace Films.Domain.Validations
{
    public class FirstLetterUppercaseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var firstLetter = value.ToString()[0].ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("The first letter must be uppercase");
            }

            return ValidationResult.Success;
        }
    }
}
