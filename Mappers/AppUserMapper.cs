using OnlineCourses.DTO_s.AppUser;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class AppUserMapper
    {
        public static AppUserDTO toAppUserDTO(this AppUser appUser)
        {
            return new AppUserDTO
            {
                Email = appUser.Email,
                isEmailConfirmed = appUser.EmailConfirmed,
                Name = appUser.Name,
                UserName = appUser.UserName,
            };
        }
        public static AppUser fromAppUserDTO(this AppUserDTO appUserdto)
        {
            return new AppUser
            {
                Email = appUserdto.Email,
                EmailConfirmed = appUserdto.isEmailConfirmed,
                Name = appUserdto.Name,
                UserName = appUserdto.UserName,
            };
        }
    }
}
