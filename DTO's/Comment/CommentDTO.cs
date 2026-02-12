using OnlineCourses.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.Comment
{
    public class CommentDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Name { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public int VideosId { get; set; }
    }
}
