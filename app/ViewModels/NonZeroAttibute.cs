using System.ComponentModel.DataAnnotations;

namespace xp_project.ViewModels
{
    public class NonZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue && intValue == 0)
            {
                return new ValidationResult("O valor deve ser diferente de zero.");
            }

            return ValidationResult.Success;
        }
    }
}
