using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.Reviews
{
    public class CreateReviewDTO
    {
        [JsonIgnore]
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [Required]
        [Range(1, 5)]
        public int StarNumbers { get; set; }
        public int CourseId { get; set; }
    }
}
