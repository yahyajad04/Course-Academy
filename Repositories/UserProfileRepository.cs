using OnlineCourses.Data;
using OnlineCourses.Interfaces;
using OnlineCourses.Models;

namespace OnlineCourses.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDbContext _context;
        public UserProfileRepository(AppDbContext context) {
            _context = context;
        }
        public async Task<UserProfile> CreateProfile(UserProfile profile)
        {
            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task<TeacherProfile> CreateProfileTeacher(TeacherProfile profile)
        {
            _context.TeacherProfiles.Add(profile);
            await _context.SaveChangesAsync();
            return profile;
        }
    }
}
