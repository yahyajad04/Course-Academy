using OnlineCourses.DTO_s.UserCourse;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class UserCourseMapper
    {
        public static UserCourseDTO toUserCourseDTO(this UserCourse userCourse)
        {
            return new UserCourseDTO
            {
                UserProfileId = userCourse.UserProfileId,
                CourseId = userCourse.CourseId,
                isPayed = userCourse.isPayed,
                isDone = userCourse.isDone,
                EnrolledAt = userCourse.EnrolledAt,
                Course = userCourse.Course.toCourseDTO(),
            };
        }
        public static CourseUserDTO toCourseUserDTO(this UserCourse userCourse)
        {
            return new CourseUserDTO
            {
                UserProfileId = userCourse.UserProfileId,
                UserProfileDTO = userCourse.UserProfile.toUserProfileDTO(),
                CourseId = userCourse.CourseId,
                isPayed = userCourse.isPayed,
                isDone = userCourse.isDone,
                EnrolledAt = userCourse.EnrolledAt,
            };
        }

        public static UserCourse fromEnrollDTO(this EnrollDTO enrollDTO) {
            return new UserCourse
            {
                UserProfileId = enrollDTO.UserProfileId,
                CourseId = enrollDTO.CourseId,
            };
        }
    }
}
