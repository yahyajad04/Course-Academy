using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.AppUser
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
