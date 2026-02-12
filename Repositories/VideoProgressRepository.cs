using Microsoft.EntityFrameworkCore;
using OnlineCourses.Data;
using OnlineCourses.DTO_s.VideoProgress;
using OnlineCourses.Interfaces;
using OnlineCourses.Models;

namespace OnlineCourses.Repositories
{
    public class VideoProgressRepository : IVideoProgressRepository
    {
        private readonly AppDbContext _context;
        public VideoProgressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VideoProgress> CreateProgress(VideoProgress progress)
        {
            var video = await _context.Videos.FindAsync(progress.VideosId);
            if (video == null)
                return null;
            progress.Videos = video;
            _context.VideoProgress.Add(progress);
            await _context.SaveChangesAsync();
            return progress;
        }

        public async Task<VideoProgress> GetProgress(string AppUserId, int Videoid)
        {
            var profile = await _context.UserProfiles.FirstOrDefaultAsync(p => p.AppUserId.Equals(AppUserId));
            return await _context.VideoProgress.Include(a => a.Videos)
                .FirstOrDefaultAsync(v => v.UserProfileId == profile.Id && v.VideosId == Videoid);
        }

        public async Task<VideoProgress> UpdateProgress(EditVideoProgressDTO progressdto)
        {
            var profile = await _context.UserProfiles.FirstOrDefaultAsync(p => p.AppUserId.Equals(progressdto.AppUserId));
            var videoprogress = await _context.VideoProgress
                .Include(a => a.Videos)
                .Include(b => b.UserProfile)
                .FirstOrDefaultAsync(v => v.UserProfileId == profile.Id
                && v.VideosId == progressdto.VideosId);
            var video = await _context.Videos.FindAsync(progressdto.VideosId);
            if (videoprogress == null || video == null)
                return null;
            videoprogress.isDone = progressdto.isDone ?? videoprogress.isDone;
            videoprogress.Progress = progressdto.Progress ?? videoprogress.Progress;

            await _context.SaveChangesAsync();
            return videoprogress;
        }
    }
}
