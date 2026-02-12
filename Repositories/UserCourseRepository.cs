using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineCourses.Data;
using OnlineCourses.DTO_s.UserCourse;
using OnlineCourses.Interfaces;
using OnlineCourses.Models;

namespace OnlineCourses.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserCourseRepository(AppDbContext context, UserManager<AppUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserCourse> DeleteUserCourse(string AppUserId, int CourseId)
        {
            var usercourse = await _context.UserCourses
                .Include(p => p.UserProfile)
                .FirstOrDefaultAsync(u => u.UserProfile.AppUserId.Equals(AppUserId) && u.CourseId == CourseId);
            if (usercourse == null) {
                return null;
            }
            _context.UserCourses.Remove(usercourse);
            await _context.SaveChangesAsync();
            return usercourse;
        }

        public async Task<UserCourse> EditUserCourse(string AppUserId, int CourseId, EditUserCourseDTO usercoursedto)
        {
            var userprof = await _context.UserProfiles.FirstOrDefaultAsync(u => u.AppUserId.Equals(AppUserId));
            if (userprof == null)
                return null;
            var usercourse = await _context.UserCourses
                .FirstOrDefaultAsync(u => u.CourseId == CourseId && u.UserProfileId == userprof.Id);
            if(usercourse == null)
            {
                return null;
            }
            usercourse.isDone = usercoursedto.isDone ?? usercourse.isDone;
            usercourse.isPayed = usercoursedto.isPayed ?? usercourse.isPayed;
            await _context.SaveChangesAsync();
            return usercourse;
        }

        public async Task<UserCourse> EnrollCourse(UserCourse usercourse)
        {
            var course = await _context.Courses.Include(u => u.UserCourses)
                .FirstOrDefaultAsync(c => c.Id == usercourse.CourseId);
            var userProfile = await _context.UserProfiles.FindAsync(usercourse.UserProfileId);
            usercourse.Course = course;
            usercourse.UserProfile = userProfile;
            if (course == null || course.UserCourses.Any(c => c.UserProfileId == usercourse.UserProfileId)) {
                return null;
            }
            _context.UserCourses.Add(usercourse);
            await _context.SaveChangesAsync();
            return usercourse;
        }

        public async Task<List<UserCourse>> GetAllCourses(string id)
        {
            return await _context.UserCourses.Include(p => p.UserProfile)
                .Where(u => u.UserProfile.AppUserId.Equals(id)).Include(c => c.Course).ToListAsync();
        }

        public async Task<List<UserCourse>> GetAllUsers(int id)
        {
            return await _context.UserCourses.Include(u => u.UserProfile).Where(c => c.CourseId == id).ToListAsync();
        }
    }
}
