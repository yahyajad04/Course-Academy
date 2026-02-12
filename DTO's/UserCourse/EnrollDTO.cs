using OnlineCourses.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineCourses.DTO_s.UserCourse
{
    public class EnrollDTO
    {
        [JsonIgnore]
        public int UserProfileId { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
