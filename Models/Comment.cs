using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public int VideosId { get; set; }
        public Videos? Videos { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
