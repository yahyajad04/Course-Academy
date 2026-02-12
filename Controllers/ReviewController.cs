using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineCourses.DTO_s.Comment;
using OnlineCourses.DTO_s.Reviews;
using OnlineCourses.Extensions;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;
using System.Diagnostics;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<AppUser> _userManager;
        public ReviewController(IReviewRepository reviewRepository, UserManager<AppUser> userManager) {
            _reviewRepository = reviewRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            var reviewsdto = reviews.Select(r => r.toReviewDTO()).ToList();

            return Ok(reviewsdto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById([FromRoute] int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if(review == null)
            {
                return NotFound("This Review Doesnt Exist");
            }
            return Ok(review.toReviewDTO());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReview(CreateReviewDTO reviewdto)
        {
            var UserId = User.GetUserId();
            var user = await _userManager.FindByIdAsync(UserId);
            var review = reviewdto.fromCreateReviewDTO();
            review.AppUserId = user.Id;
            review.Name = user.Name;
            review.AppUser = user;

            var review2 = await _reviewRepository.CreateAsync(review);

            if (review2 == null)
                return NotFound("The Cousre for this review is not found");

            return Ok(review2.toReviewDTO());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditReview([FromRoute] int id, EditReviewDTO reviewdto)
        {
            var UserId = User.GetUserId() ?? string.Empty;
            var review1 = await _reviewRepository.GetByIdAsync(id);
            if (review1 == null) {
                return NotFound("Review Doesnt Exist");
            }

            if (!UserId.Equals(review1.AppUserId) && !review1.AppUserId.IsNullOrEmpty())
            {
                return Forbid("You are not authorized to edit this comment");
            }
            var review = await _reviewRepository.EditAsync(id, reviewdto);
            if(review == null)
            {
                return NotFound("This Review Doesnt Exist");
            }

            return Ok(review.toReviewDTO());
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            var review1 = await _reviewRepository.GetByIdAsync(id);
            if (review1 == null)
                return NotFound("This Review Doent Exist");

            var UserId = User.GetUserId() ?? string.Empty;

            if (!UserId.Equals(review1.AppUserId) && !review1.AppUserId.IsNullOrEmpty())
            {
                return Forbid("You are not authorized to delete this comment");
            }
            var review = await _reviewRepository.DeleteAsync(id);
            if(review == null)
            {
                return NotFound("This Review Doesnt Exist");
            }

            return Ok(review.toReviewDTO());
        }
    }
}
