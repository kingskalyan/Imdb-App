using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomValidation
{
    public class YearValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var res = DateTime.TryParse(value.ToString(), out var year);

            if (res == true)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Value should be Date format");
        }
    }
}
