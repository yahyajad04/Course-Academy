using OnlineCourses.DTO_s.Comment;
using OnlineCourses.Models;

namespace OnlineCourses.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO toCommentDTO(this Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                CreateDate = comment.CreateDate,
                Description = comment.Description,
                Name = comment.Name,
                Title = comment.Title,
                VideosId = comment.VideosId 
            };
        }

        public static Comment fromCreateCommentDTO(this CreateCommentDTO createCommentDTO)
        {
            return new Comment
            {
                VideosId = createCommentDTO.VideosId,
                Title = createCommentDTO.Title,
                Name = createCommentDTO.Name,
                Description = createCommentDTO.Description,
            };
        }
    }
}
