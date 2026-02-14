using OnlineCourses.DTO_s.UserProfile;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class UserProfileMapper
    {
        public static UserProfileDTO toUserProfileDTO(this UserProfile userProfile)
        {
            return new UserProfileDTO
            {
                Id = userProfile.Id,
                AppUserId = userProfile.AppUserId,
                AppUserDTO = userProfile.AppUser.toAppUserDTO(),
            };
        }

        public static UserProfile fromUserProfileDTO(this UserProfileDTO userProfiledto) {
            return new UserProfile
            {
                Id = userProfiledto.Id,
                AppUserId = userProfiledto.AppUserId,
                AppUser = userProfiledto.AppUserDTO.fromAppUserDTO(),
            };
        }
    }
}
