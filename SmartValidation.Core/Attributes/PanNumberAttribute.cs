using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartValidation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PanNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pan = value as string;

            if (string.IsNullOrWhiteSpace(pan))
            {
                return ValidationResult.Success;
            }

            // PAN format: 5 letters + 4 digits + 1 letter
            if (!Regex.IsMatch(pan, @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$"))
            {
                return new ValidationResult("Invalid PAN number format. It should be 5 letters followed by 4 digits and 1 letter (e.g., ABCDE1234F).");
            }

            return ValidationResult.Success;
        }
    }
}
