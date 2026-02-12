using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.AppUser
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
