using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.Videos
{
    public class CreateVideosDTO
    {
        [Required]
        public string? VideoLink { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int? SortOrder { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public int CourseId { get; set; }
    }
}
