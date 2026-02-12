using OnlineCourses.DTO_s.AppUser;
using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface IEmailService
    {
        Task<bool> VerifyEmail(string email, int? code);
    }
}
