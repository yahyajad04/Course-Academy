using OnlineCourses.DTO_s.Reviews;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(int id);
        Task<Review> CreateAsync(Review reviewdto);
        Task<Review> EditAsync(int id, EditReviewDTO reviewdto);
        Task<Review> DeleteAsync(int id);

    }
}
