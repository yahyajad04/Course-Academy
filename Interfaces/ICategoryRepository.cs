using OnlineCourses.DTO_s;
using OnlineCourses.DTO_s.Categories;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> CreateAsync(CreateCategoryDTO categorycdto); 
        Task<Category> EditAsync(int id, EditCategoryDTO categoryedto); 
        Task<Category> DeleteAsync(int id); 
    }
}
