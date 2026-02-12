using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [Required]
        [Range(1,5)]
        public int StarNumbers { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
