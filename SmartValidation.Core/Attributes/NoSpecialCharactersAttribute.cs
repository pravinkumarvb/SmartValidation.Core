using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartValidation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NoSpecialCharactersAttribute : ValidationAttribute
    {
        private const string LeadingSpaceErrorMessage = "The field should not start with a space.";
        private const string SpecialCharacterErrorMessage = "The field should not contain special characters.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success; // Allow null. Use [Required] separately.

            string input = value.ToString();

            // Check for leading space
            if (input.StartsWith(" "))
            {
                return new ValidationResult(LeadingSpaceErrorMessage);
            }

            // Allow letters, numbers, and spaces. Disallow special characters.
            var regex = new Regex(@"^[a-zA-Z0-9 ]+$");
            if (!regex.IsMatch(input))
            {
                return new ValidationResult(SpecialCharacterErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
