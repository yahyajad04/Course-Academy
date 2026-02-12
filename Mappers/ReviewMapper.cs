using OnlineCourses.DTO_s.Reviews;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDTO toReviewDTO(this Review review)
        {
            return new ReviewDTO
            {
                Id = review.Id,
                Name = review.Name,
                Title = review.Title,
                StarNumbers = review.StarNumbers,
                CreatedAt = review.CreatedAt,
                CourseId = review.CourseId,
            };
        }

        public static Review fromCreateReviewDTO(this CreateReviewDTO createReviewDTO) {
            return new Review
            {
                Name = createReviewDTO.Name,
                Title = createReviewDTO.Title,
                StarNumbers = createReviewDTO.StarNumbers,
                CourseId = createReviewDTO.CourseId,
            };
        }
    }
}
