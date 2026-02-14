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

        public async Task<UserProfile> DeleteProfile(int Id)
        {
            var userprofile = await _context.UserProfiles.FindAsync(Id);
            if (userprofile == null)
                return null;
            _context.UserProfiles.Remove(userprofile);
            await _context.SaveChangesAsync();
            return userprofile;
        }
    }
}
