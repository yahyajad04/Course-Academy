using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineCourses.Data;
using OnlineCourses.DTO_s.Courses;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;

namespace OnlineCourses.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Course> CreateAsync(CreateCourseDTO coursedto)
        {
            var course = coursedto.fromCreateCourseDTO();
            var category = await _context.Categories.FindAsync(course.CategoryId);
            if (category == null) {
                return null;
            }
            _context.Courses.Add(course);
            await _context.SaveChangesAsync(); 
            return course;
        }

        public async Task<Course> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if(course == null)
            {
                return null;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> EditAsync(int id, EditCourseDTO coursedto)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if(course == null)
            {
                return null;
            }
            course.Name = coursedto.Name ?? course.Name;
            course.Description = coursedto.Description ?? course.Description;
            course.IsPublished = coursedto.IsPublished ?? course.IsPublished;
            course.Difficulty = coursedto.Difficulty ?? course.Difficulty;
            course.ImageUrl = coursedto.ImageUrl ?? course.ImageUrl;
            course.Price = coursedto.Price ?? course.Price;
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.Include(c => c.Videos).Include(r => r.Reviews).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(c => c.Videos).Include(r => r.Reviews).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
