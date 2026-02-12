using OnlineCourses.Models;

namespace OnlineCourses.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(AppUser user);
    }
}
