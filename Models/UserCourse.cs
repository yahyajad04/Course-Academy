namespace OnlineCourses.Models
{
    public class UserCourse
    {
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public bool? isDone { get; set; } = false;
        public bool? isPayed { get; set; } = false;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

    }
}
