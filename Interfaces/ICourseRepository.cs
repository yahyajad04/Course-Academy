using OnlineCourses.DTO_s.Courses;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<Course> CreateAsync(CreateCourseDTO coursedto);
        Task<Course> EditAsync(int id, EditCourseDTO coursedto);
        Task<Course> DeleteAsync(int id);
    }
}
