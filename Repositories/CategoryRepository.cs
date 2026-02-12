using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineCourses.Data;
using OnlineCourses.DTO_s.Categories;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;

namespace OnlineCourses.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Category> CreateAsync(CreateCategoryDTO categorycdto)
        {
            var category = categorycdto.fromCreateCategoryDTO();
            
            if(_context.Categories.Contains(category))
            {
                return null;
            }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> EditAsync(int id, EditCategoryDTO categoryedto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) {
                return null;
            }

            category.Name = categoryedto.Name ?? category.Name;
            category.Description = categoryedto.Description ?? category.Description;
            category.ImageUrl = categoryedto.ImageUrl ?? category.ImageUrl;

            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Courses).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Courses).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
