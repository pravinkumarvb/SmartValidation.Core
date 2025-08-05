using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartValidation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class NoSpecialCharactersOrNumbersAttribute : ValidationAttribute
    {
        private const string LeadingSpaceErrorMessage = "The field should not start with a space.";
        private const string LeadingNumberErrorMessage = "The first letter must not be a number.";
        private const string SpecialCharacterNumberErrorMessage = "The field must not contain special characters or numbers.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = value as string;

            if (string.IsNullOrWhiteSpace(input))
                return ValidationResult.Success;

            if (char.IsWhiteSpace(input[0]))
                return new ValidationResult(LeadingSpaceErrorMessage);

            if (char.IsDigit(input[0]))
                return new ValidationResult(LeadingNumberErrorMessage);

            if (Regex.IsMatch(input, @"[^a-zA-Z\s]"))
                return new ValidationResult(SpecialCharacterNumberErrorMessage);

            return ValidationResult.Success;
        }
    }
}
