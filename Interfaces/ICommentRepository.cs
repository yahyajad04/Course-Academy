using OnlineCourses.DTO_s.Comment;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetBYIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment> EditAsync(int id, EditCommentDTO commentdto);
        Task<Comment> DeleteAsync(int id);
    }
}
