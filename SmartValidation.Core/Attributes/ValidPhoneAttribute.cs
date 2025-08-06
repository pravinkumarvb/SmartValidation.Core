using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartValidation.Core.Attributes
{
    
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ValidPhoneAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Invalid phone number format.";

        public ValidPhoneAttribute()
        {
            ErrorMessage = DefaultErrorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Allow null or empty — [Required] should handle that
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.Success;

            string phone = value.ToString();

            if(string.IsNullOrEmpty(phone))
                return ValidationResult.Success; // Null is allowed — use [Required] for that

            // Accepts formats like "9876543210", "+919876543210", "91-9876543210", "0919876543210"
            var regex = new Regex(@"^(\+91[\-\s]?|91[\-\s]?|0)?[6-9]\d{9}$");


            if (regex.IsMatch(phone))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
