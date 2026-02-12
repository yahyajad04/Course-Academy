using OnlineCourses.DTO_s.VideoProgress;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface IVideoProgressRepository
    {
        Task<VideoProgress> GetProgress(string AppUserId ,int Videoid);
        Task<VideoProgress> CreateProgress(VideoProgress progress);
        Task<VideoProgress> UpdateProgress(EditVideoProgressDTO progressdto);
    }
}
