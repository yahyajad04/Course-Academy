using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> CreateProfile(UserProfile profile);
        Task<TeacherProfile> CreateProfileTeacher(TeacherProfile profile);
    }
}
