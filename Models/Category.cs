using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
