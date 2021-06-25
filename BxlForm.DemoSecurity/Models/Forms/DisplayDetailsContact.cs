using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Models.Forms
{
    public class DisplayDetailsContact
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Catégorie")]
        public int CategoryId { get; set; }
    }
}
