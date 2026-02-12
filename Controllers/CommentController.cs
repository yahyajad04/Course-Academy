using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineCourses.DTO_s.Comment;
using OnlineCourses.Extensions;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;
using System.Diagnostics;
using System.Windows.Input;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentRepository commentRepo, UserManager<AppUser> userManager) {
            _commentRepo = commentRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentsdto = comments.Select(c => c.toCommentDTO()).ToList();

            return Ok(commentsdto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetBYIdAsync(id);
            if(comment == null)
            {
                return NotFound("This Comment Doesnt Exist");
            }

            return Ok(comment.toCommentDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDTO commentdto)
        {
            var UserId = User.GetUserId();
            var user = await _userManager.FindByIdAsync(UserId);

            var comment = commentdto.fromCreateCommentDTO();
            comment.Name = user.Name;
            comment.AppUserId = user.Id;
            comment.AppUser = user;

            comment = await _commentRepo.CreateAsync(comment);
            if (comment == null)
                return NotFound("The Video for this Comment Doesnt Exist");

            return Ok(comment.toCommentDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditComment([FromRoute] int id, EditCommentDTO commentdto)
        {
            var UserId = User.GetUserId();
            var comment = await _commentRepo.GetBYIdAsync(id);
            if (!UserId.Equals(comment.AppUserId) && !comment.AppUserId.IsNullOrEmpty())
            {
                return Forbid("You are not authorized to edit this comment");
            }

            var comment2 = await _commentRepo.EditAsync(id, commentdto);
            if(comment2 == null)
            {
                return NotFound("This Comment Doesnt Exist");
            }

            return Ok(comment2.toCommentDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment1 = await _commentRepo.GetBYIdAsync(id);
            var UserId = User.GetUserId();
            if (!UserId.Equals(comment1.AppUserId))
            {
                return Forbid("You are not authorized to delete this comment");
            }
            var comment = await _commentRepo.DeleteAsync(id);
            if(comment == null)
            {
                return NotFound("This Comment Doesnt Exist");
            }

            return Ok(comment.toCommentDTO());
        }
    }
}
