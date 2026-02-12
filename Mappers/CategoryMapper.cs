using OnlineCourses.DTO_s;
using OnlineCourses.DTO_s.Categories;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDTO toCategoryDTO(this Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                CreateDate = category.CreateDate,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
                Courses = category.Courses.Select(c => c.toCourseDTO()).ToList(),
            };
        }

        public static Category fromCreateCategoryDTO(this CreateCategoryDTO categoryDTO) {
            return new Category
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                ImageUrl = categoryDTO.ImageUrl,
            };
        }
    }
}
