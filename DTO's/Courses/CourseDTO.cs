using OnlineCourses.DTO_s.Reviews;
using OnlineCourses.DTO_s.UserCourse;
using OnlineCourses.DTO_s.Videos;
using OnlineCourses.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.Courses
{
    public class CourseDTO
    {
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
        public int CategoryId { get; set; }
        public List<VideosDTO> Videos { get; set; } = new List<VideosDTO>();
        public List<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
        public ICollection<UserCourseDTO> UserCourses { get; set; } = new List<UserCourseDTO>();
        public int TeacherProfileId { get; set; }
    }
}
