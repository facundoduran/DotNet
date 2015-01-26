using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancesTechniques.UP.Business.Validators
{
    public class NumericAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int number;

            if (value != null && Int32.TryParse(value.ToString(), out number))
            {
                return ValidationResult.Success;
            }

            var errorMessage = FormatErrorMessage(validationContext.DisplayName);

            return new ValidationResult(errorMessage);
        }
    }
}
