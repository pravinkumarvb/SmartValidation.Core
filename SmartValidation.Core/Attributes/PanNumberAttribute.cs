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
            var aadhaar = value as string;

            if (string.IsNullOrWhiteSpace(aadhaar))
            {
                return ValidationResult.Success;
            }

            // Aadhaar format: exactly 12 digits, cannot start with 0 or 1
            if (!Regex.IsMatch(aadhaar, @"^[2-9]{1}[0-9]{11}$"))
            {
                return new ValidationResult("Invalid Aadhaar number. It must be a 12-digit number starting with digits 2–9.");
            }

            return ValidationResult.Success;
        }
    }
}
