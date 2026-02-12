using System.ComponentModel.DataAnnotations;

namespace OnlineCourses.DTO_s.Categories
{
    public class EditCategoryDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
