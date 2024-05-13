using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
