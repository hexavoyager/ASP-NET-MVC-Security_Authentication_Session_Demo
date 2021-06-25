using BxlForm.DemoSecurity.Models.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Infrastructure.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            string email = value as string;

            if(!string.IsNullOrWhiteSpace(email))
            {
                if(authRepository.EmailExists(email))
                {
                    return new ValidationResult("Email already exists in database!!");                    
                }
            }
            else
            {
                return new ValidationResult($"Invalid value in the field : {validationContext.MemberName}");
            }

            return ValidationResult.Success;
        }
    }
}
