using OnlineCourses.DTO_s.Videos;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface IVideosRepository
    {
        Task<List<Videos>> GetAllAsync();
        Task<Videos> GetByIdAsync(int id);
        Task<Videos> CreateAsync(CreateVideosDTO videosDTO);
        Task<Videos> EditAsync(int id, EditVideosDTO videosDTO);
        Task<Videos> DeleteAsync(int id);
    }
}
