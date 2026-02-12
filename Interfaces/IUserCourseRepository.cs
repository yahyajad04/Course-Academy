using OnlineCourses.DTO_s.UserCourse;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface IUserCourseRepository
    {
        Task<List<UserCourse>> GetAllCourses(string id);
        Task<List<UserCourse>> GetAllUsers(int id);
        Task<UserCourse> EnrollCourse(UserCourse usercourse);
        Task<UserCourse> EditUserCourse(string AppUserId, int CourseId, EditUserCourseDTO usercoursedto);
        Task<UserCourse> DeleteUserCourse(string AppUserId, int CourseId);
    }
}
