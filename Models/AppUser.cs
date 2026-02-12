using Microsoft.AspNetCore.Identity;

namespace OnlineCourses.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public int? EmailVerificationCode { get; set; }
        public UserProfile? UserProfile { get; set; }
        public TeacherProfile? Teacher { get; set; }
    }
}
