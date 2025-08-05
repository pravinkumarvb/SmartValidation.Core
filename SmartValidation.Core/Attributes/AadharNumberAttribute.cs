using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmartValidation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AadharNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true; // Handled by [Required] if needed

            string aadhar = value.ToString().Trim();

            // Aadhar must be exactly 12 digits and not start with 0 or 1
            var regex = new Regex(@"^[2-9]{1}[0-9]{11}$");

            if (!Regex.IsMatch(regex))
            {
                return new ValidationResult("Invalid Aadhar number. It must be 12 digits and not start with 0 or 1.");
            }

            return ValidationResult.Success;
        }
    }
}
