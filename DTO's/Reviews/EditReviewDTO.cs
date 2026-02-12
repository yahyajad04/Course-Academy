using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.Reviews
{
    public class EditReviewDTO
    {
        public string? Title { get; set; }
        [Required]
        [Range(1, 5)]
        public int? StarNumbers { get; set; }
    }
}
