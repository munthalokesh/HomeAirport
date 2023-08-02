using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport.Models.DataLayer
{
    public class CustomDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateOfBirth = (DateTime)value;



                // Check if the date of birth is less than today's date
                if (dateOfBirth.Date >= DateTime.Now.Date)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }



            return ValidationResult.Success;
        }



    }
}