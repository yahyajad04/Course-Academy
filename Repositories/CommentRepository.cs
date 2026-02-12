using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.Data;
using OnlineCourses.DTO_s.Comment;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;
using System.Windows.Input;

namespace OnlineCourses.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            var video = await _context.Videos.FindAsync(comment.VideosId);
            if (video == null) {
                return null;
            }
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) {
                return null;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment> EditAsync(int id, EditCommentDTO commentdto)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) {
                return null;
            }
            comment.Title = commentdto.Title ?? comment.Title;
            comment.Description = commentdto.Description ?? comment.Description;

            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetBYIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}
