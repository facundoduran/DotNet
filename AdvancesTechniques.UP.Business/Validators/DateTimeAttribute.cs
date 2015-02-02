using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancesTechniques.UP.Business.Validators
{
    public class DateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dtout;

            if (value != null && DateTime.TryParse(value.ToString(), out dtout))
            {
                return ValidationResult.Success;
            }

            var errorMessage = FormatErrorMessage(validationContext.DisplayName);

            return new ValidationResult(errorMessage, new string[] { validationContext.MemberName });
        }
    }
}
