using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.DTO_s.VideoProgress;
using OnlineCourses.Extensions;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideoProgressController : ControllerBase
    {
        private readonly IVideoProgressRepository _videoProgressRepository;
        private readonly UserManager<AppUser> _userManager;
        public VideoProgressController(IVideoProgressRepository videoProgressRepository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _videoProgressRepository = videoProgressRepository;
        }

        [HttpGet("{VideoId}")]
        public async Task<IActionResult> GetProgress([FromRoute] int VideoId)
        {
            var userId = User.GetUserId();
            var progress = await _videoProgressRepository.GetProgress(userId, VideoId);

            if(progress == null) 
                return NotFound("Video Doesnt Exist");
            return Ok(progress.toVideoProgressDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgress(CreateVideoProgressDTO progressdto)
        {
            var userId = User.GetUserId();
            var user = await _userManager.Users.Include(u => u.UserProfile)
                .FirstOrDefaultAsync(a => a.Id == userId);

            progressdto.UserProfileId = user.UserProfile.Id;
            progressdto.UserProfileDTO = user.UserProfile.toUserProfileDTO();
            var progressbefore = progressdto.fromCreateVideoProgressDTO();
            var progress = await _videoProgressRepository.CreateProgress(progressbefore);

            if (progress == null)
                return NotFound("There is no Progress/Video");

            return Ok(progress.toVideoProgressDTO());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgress(EditVideoProgressDTO progressdto)
        {
            var userId = User.GetUserId();
            progressdto.AppUserId = userId;
            var progress = await _videoProgressRepository.UpdateProgress(progressdto);

            if (progress == null)
                return NotFound("This Progress/Video NotFound");

            return Ok(progress.toVideoProgressDTO());
        }
    }
}
