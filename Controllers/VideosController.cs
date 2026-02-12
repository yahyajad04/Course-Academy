using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCourses.DTO_s.Videos;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideosController : ControllerBase
    {
        private readonly IVideosRepository _videosRepository;
        public VideosController(IVideosRepository videosRepository) { 
            _videosRepository = videosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVideos()
        {
            var videos = await _videosRepository.GetAllAsync();
            var videosdto = videos.Select(v => v.toVideosDTO());

            return Ok(videosdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllVideos([FromRoute] int id)
        {
            var video = await _videosRepository.GetByIdAsync(id);
            if (video == null) { 
                return NotFound("This Video Doesnt Exist");
            }
            return Ok(video.toVideosDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideosDTO videosDTO)
        {
            var video = await _videosRepository.CreateAsync(videosDTO);
            if (video == null) { 
                return NotFound("The Course for this video is not found");
            }
            return Ok(video.toVideosDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditVideo([FromRoute] int id, EditVideosDTO videosDTO)
        {
            var video = await _videosRepository.EditAsync(id, videosDTO);

            if (video == null) { 
                return NotFound("This Video doesnt Exist");
            }
            return Ok(video.toVideosDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo([FromRoute] int id)
        {
            var video = await _videosRepository.DeleteAsync(id);

            if (video == null) { 
                return NotFound("This Video Doesnt Exist");
            }
            return Ok(video.toVideosDTO());
        }

    }
}
