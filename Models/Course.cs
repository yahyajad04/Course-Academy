using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OnlineCourses.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        [Required]
        public string? Difficulty { get; set; }
        public bool IsPublished { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<Videos> Videos { get; set; } = new List<Videos>();
        public List<Review> Reviews { get; set; } = new List<Review>();

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
        public int TeacherProfileId { get; set; }
        public TeacherProfile? Teacher { get; set; }

    }
}
