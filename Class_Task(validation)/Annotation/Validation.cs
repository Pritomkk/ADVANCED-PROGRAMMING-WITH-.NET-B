using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Class_Task_validation_.Annotation
{
    public class ValidaetionName: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null && value is string)
            {
             
                string name = (string)value;
                if (name.All(char.IsLetter))
                {

                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Name should contain only alphabets.");
        }

    }
    public class ValidationId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string)
            {
                string id = (string)value;
                if (Regex.IsMatch(id, @"^\d{2}-\d{5}-[1-3]$"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("ID format is 21-44407-1");
        }
    }

    public class ValidationUserName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string)
            {
                string username = (string)value;
                if (username.Length <= 10 && !username.Contains(" ") && System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9\W]+$"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Username contains 10 characters, numbers and special characters allowed.");
        }

    }

    public class ValidationEmail: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string)
            {
                string email = (string)value;
                if (Regex.IsMatch(email, @"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Email format is xx-xxxxx-x@student.aiub.edu");
        }
    }
}
