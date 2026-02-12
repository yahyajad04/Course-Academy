using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.Reviews
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [Required]
        [Range(1, 5)]
        public int StarNumbers { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CourseId { get; set; }
    }
}
