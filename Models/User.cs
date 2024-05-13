using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
    public class User
    {
        public enum UserRole
        {
            Admin = 1,
            User = 2
        }

        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
