using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancesTechniques.UP.Business.Validators
{
    public class DateEqualTo : ValidationAttribute
    {
        private string datePropertyName;

        public DateEqualTo(string datePropertyName, string errorMessage) : base(errorMessage)
        {
            this.datePropertyName = datePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.datePropertyName);

                if (otherPropertyInfo.PropertyType.Equals(typeof(DateTime?)))
                {
                    DateTime? toValidate = (DateTime?)value;
                    DateTime? referenceProperty = (DateTime?)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                    bool datesAreEqual = toValidate.HasValue && referenceProperty.HasValue && toValidate.Value.CompareTo(referenceProperty.Value) == 0;

                    if (datesAreEqual)
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return new ValidationResult("An error occurred while validating the property. OtherProperty is not of type DateTime");
                }
            }
            catch (Exception ex)
            {
                // Do stuff, i.e. log the exception
                // Let it go through the upper levels, something bad happened
                throw ex;
            }

            var errorMessage = FormatErrorMessage("Error");

            return new ValidationResult(errorMessage, new string[] { validationContext.MemberName });
        }
    }
}
