using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BxlForm.DemoSecurity.Infrastructure.Validation
{
    public class CategoryIdValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int categoryId = (int)value;

            ICategoryRepository categoryService = (ICategoryRepository)validationContext.GetService(typeof(ICategoryRepository));
            Category category = categoryService.Get().Where(c => c.Id == categoryId).SingleOrDefault();

            if (category is null)
            {
                return new ValidationResult("Cette catégorie n'existe pas");
            }
                
            return ValidationResult.Success;                
        }
    }
}
