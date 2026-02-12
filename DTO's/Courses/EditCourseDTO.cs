using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.Courses
{
    public class EditCourseDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Difficulty { get; set; }
        public bool? IsPublished { get; set; }
    }
}
