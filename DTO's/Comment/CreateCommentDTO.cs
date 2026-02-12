using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.Comment
{
    public class CreateCommentDTO
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [JsonIgnore]
        public string? Name { get; set; }
        public int VideosId { get; set; }
    }
}
