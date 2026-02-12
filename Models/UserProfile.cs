namespace OnlineCourses.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
    }
}
