using System.ComponentModel.DataAnnotations;

namespace BxlForm.DemoSecurity.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
    }
}
