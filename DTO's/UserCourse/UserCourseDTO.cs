using OnlineCourses.DTO_s.Courses;
using OnlineCourses.DTO_s.UserProfile;
using OnlineCourses.Models;

namespace OnlineCourses.DTO_s.UserCourse
{
    public class UserCourseDTO
    {
        public int UserProfileId { get; set; }
        public UserProfileDTO? UserProfileDTO { get; set; }
        public int CourseId { get; set; }
        public CourseDTO? Course { get; set; }
        public bool? isDone { get; set; } = false;
        public bool? isPayed { get; set; } = false;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}
