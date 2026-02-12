namespace OnlineCourses.Models
{
    public class TeacherProfile
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
