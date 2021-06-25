using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BxlForm.DemoSecurity.Models.Forms
{
    public class DisplayContact
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
    }
}
