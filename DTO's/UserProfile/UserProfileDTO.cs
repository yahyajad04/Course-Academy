using OnlineCourses.DTO_s.AppUser;

namespace OnlineCourses.DTO_s.UserProfile
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public AppUserDTO? AppUserDTO { get; set; }
    }
}
