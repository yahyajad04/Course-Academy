using OnlineCourses.DTO_s.Videos;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class VideosMapper
    {
        public static VideosDTO toVideosDTO(this Videos video)
        {
            return new VideosDTO
            {
                Id = video.Id,
                Author = video.Author,
                CourseId = video.CourseId,
                Description = video.Description,
                SortOrder = video.SortOrder,
                Title = video.Title,
                VideoLink = video.VideoLink,
                Comments = video.Comments.Select(c => c.toCommentDTO()).ToList(), 
            };
        }

        public static Videos fromCreateVideosDTO(this CreateVideosDTO videosDTO) {
            return new Videos
            {
                Title = videosDTO.Title,
                Author = videosDTO.Author,
                CourseId = videosDTO.CourseId,
                Description = videosDTO.Description,
                SortOrder = videosDTO.SortOrder,
                VideoLink = videosDTO.VideoLink
            };
        }
    }
}
