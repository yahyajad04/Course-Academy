using OnlineCourses.DTO_s.Courses;
using OnlineCourses.Models;

namespace OnlineCourses.DTO_s.UserCourse
{
    public class CourseUserDTO
    {
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
        public int CourseId { get; set; }
        public bool? isDone { get; set; } = false;
        public bool? isPayed { get; set; } = false;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}
