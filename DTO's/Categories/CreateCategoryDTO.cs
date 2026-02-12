using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.Categories
{
    public class CreateCategoryDTO
    {
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
