using CarParts.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarParts.Helpers.CustomValidation
{
    public class checkEmailExisting : ValidationAttribute
    {

        protected override ValidationResult IsValid(object email, ValidationContext validationContext)
        {
            var service = (UserManager<DbUser>)validationContext
                   .GetService(typeof(UserManager<DbUser>));
            var user = service.FindByEmailAsync(email.ToString()).Result;
            if (user != null)
            {
                return new ValidationResult(null);
            }
            return ValidationResult.Success;
        }
    }
}
