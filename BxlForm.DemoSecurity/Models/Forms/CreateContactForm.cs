using BxlForm.DemoSecurity.Infrastructure.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BxlForm.DemoSecurity.Models.Forms
{
    public class CreateContactForm
    {
        [Required]
        [StringLength(75)]
        [DisplayName("Nom : ")]
        public string LastName { get; set; }
        [Required]
        [StringLength(75)]
        [DisplayName("Prenom : ")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(384)]
        [EmailAddress]
        [DisplayName("Email : ")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Catégorie : ")]
        [CategoryIdValidation]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        //public IEnumerable<Category> Categories { get; set; }
    }
}
