using OnlineCourses.DTO_s.Courses;
using OnlineCourses.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();

    }
}
