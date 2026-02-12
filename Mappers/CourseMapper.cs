using OnlineCourses.DTO_s.Courses;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class CourseMapper
    {
        public static CourseDTO toCourseDTO(this Course course)
        {
            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                CreateDate = course.CreateDate,
                Difficulty = course.Difficulty,
                ImageUrl = course.ImageUrl,
                IsPublished = course.IsPublished,
                CategoryId = course.CategoryId,
                Videos = course.Videos.Select(v => v.toVideosDTO()).ToList(),
                Reviews = course.Reviews.Select(r => r.toReviewDTO()).ToList(),
                Price = course.Price,
                TeacherProfileId = course.TeacherProfileId,
            };
        }

        public static Course fromCreateCourseDTO(this CreateCourseDTO createCourseDTO)
        {
            return new Course
            {
                Name = createCourseDTO.Name,
                Description = createCourseDTO.Description,
                ImageUrl= createCourseDTO.ImageUrl,
                Difficulty= createCourseDTO.Difficulty,
                IsPublished = createCourseDTO.IsPublished,
                CategoryId = createCourseDTO.CategoryId,
                Price = createCourseDTO.Price,
                TeacherProfileId = createCourseDTO.TeacherProfileId,
            };
        }    
    }
}
