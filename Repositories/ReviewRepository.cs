using Microsoft.EntityFrameworkCore;
using OnlineCourses.Data;
using OnlineCourses.DTO_s.Reviews;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;

namespace OnlineCourses.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Review> CreateAsync(Review review)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == review.CourseId);
            if (course == null) {
                return null;
            }
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeleteAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) {
                return null;
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> EditAsync(int id, EditReviewDTO reviewdto)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) {
                return null;
            }

            review.Title = reviewdto.Title ?? review.Title;
            review.StarNumbers = reviewdto.StarNumbers ?? review.StarNumbers;

            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }
    }
}
