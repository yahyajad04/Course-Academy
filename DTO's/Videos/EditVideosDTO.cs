using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.Videos
{
    public class EditVideosDTO
    {
        public string? Title { get; set; }
        public int? SortOrder { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
