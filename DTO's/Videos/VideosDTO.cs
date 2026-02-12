using OnlineCourses.DTO_s.Comment;
using OnlineCourses.DTO_s.VideoProgress;
using OnlineCourses.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.Videos
{
    public class VideosDTO
    {
        public int Id { get; set; }
        [Required]
        public string? VideoLink { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int? SortOrder { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public List<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
    }
}
