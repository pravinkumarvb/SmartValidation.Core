using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartValidation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class IndianPostalCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pin = value as string;

            if (string.IsNullOrWhiteSpace(pin))
            {
                return ValidationResult.Success;
            }

            // Indian PIN code: 6 digits, first digit should be 1-9
            if (!Regex.IsMatch(pin, @"^[1-9][0-9]{5}$"))
            {
                return new ValidationResult("Invalid Postal Code format. It should be a 6-digit number starting from 1-9 (e.g., 110001).");
            }

            return ValidationResult.Success;
        }
    }
}
