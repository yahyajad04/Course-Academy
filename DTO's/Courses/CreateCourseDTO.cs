using OnlineCourses.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.Courses
{
    public class CreateCourseDTO
    {
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        [Required]
        public string? Difficulty { get; set; }
        public decimal? Price { get; set; }
        public bool IsPublished { get; set; } = false;
        public int CategoryId { get; set; }
        [JsonIgnore]
        public int TeacherProfileId { get; set; }
    }
}
