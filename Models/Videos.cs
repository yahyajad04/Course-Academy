using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.Models
{
    public class Videos
    {
        [Key]
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
        public Course? Course { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
