using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.Comment
{
    public class EditCommentDTO
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
