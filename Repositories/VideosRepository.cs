using Microsoft.EntityFrameworkCore;
using OnlineCourses.Data;
using OnlineCourses.DTO_s.VideoProgress;
using OnlineCourses.DTO_s.Videos;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;

namespace OnlineCourses.Repositories
{
    public class VideosRepository : IVideosRepository
    {
        private readonly AppDbContext _context;
        public VideosRepository(AppDbContext context) {
            _context = context;
        }
        public async Task<Videos> CreateAsync(CreateVideosDTO videosDTO)
        {
            var video = videosDTO.fromCreateVideosDTO();
            var course = await _context.Courses.FindAsync(video.CourseId);
            if (course == null) {
                return null;
            }
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return video;
        }

        public async Task<Videos> DeleteAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video == null) {
                return null;
            }

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return video;
        }

        public async Task<Videos> EditAsync(int id, EditVideosDTO videosDTO)
        {
            var video = await _context.Videos.FindAsync(id);
            if(video == null)
            {
                return null;
            }
            video.Author = videosDTO.Author ?? video.Author;
            video.Description = videosDTO.Description ?? video.Description;
            video.Title = videosDTO.Title ?? video.Title;
            video.SortOrder = videosDTO.SortOrder ?? video.SortOrder;

            await _context.SaveChangesAsync();
            return video;
        }

        public async Task<List<Videos>> GetAllAsync()
        {
            return await _context.Videos.Include(v => v.Comments).ToListAsync();
        }

        public async Task<Videos> GetByIdAsync(int id)
        {
            return await _context.Videos.Include(v => v.Comments).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
