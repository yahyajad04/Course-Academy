using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.DTO_s.UserCourse;
using OnlineCourses.Extensions;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly UserManager<AppUser> _userManager;
        public UserCourseController(IUserCourseRepository userCourseRepository, UserManager<AppUser> userManager)
        {
            _userCourseRepository = userCourseRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCourses()
        {
            var AppUserId = User.GetUserId();
            var courses = await _userCourseRepository.GetAllCourses(AppUserId);
            if (courses == null) { 
                return NotFound("No Courses Are Found");
            }
            var coursesdto = courses.Select(c => c.toUserCourseDTO()).ToList();
            return Ok(coursesdto);
        }
        [HttpGet("{CourseId}")]
        public async Task<IActionResult> GetAllUsers([FromRoute] int CourseId)
        {
            var courseusers = await _userCourseRepository.GetAllUsers(CourseId);
            if (courseusers == null) {
                return BadRequest("This Course Doesnt Exist/Doesnt Have Users");
            }
            var courseusersdto = courseusers.Select(c => c.toCourseUserDTO()).ToList();
            return Ok(courseusersdto);
        }
        [HttpPost]
        public async Task<IActionResult> EnrollCourse(EnrollDTO enrollDTO)
        {
            var userId = User.GetUserId();
            var user = await _userManager.Users.Include(p => p.UserProfile).FirstOrDefaultAsync(u => u.Id.Equals(userId));
            if (user == null)
            {
                return NotFound("User Doesnt Exist"); 
            }
            enrollDTO.UserProfileId = user.UserProfile.Id;
            var usercourse1 = enrollDTO.fromEnrollDTO();
            var usercourse = await _userCourseRepository.EnrollCourse(usercourse1);
            if (usercourse == null) {
                return BadRequest("This User Already Enrolled/Course Doesnt Exist");
            }

            return Ok(usercourse.toUserCourseDTO());
        }

        [HttpPut("{CourseId}")]
        [Authorize]
        public async Task<IActionResult> EditUserCourse([FromRoute] int CourseId, EditUserCourseDTO usercoursedto)
        {
            var userId = User.GetUserId();
            var usercourse = await _userCourseRepository.EditUserCourse(userId, CourseId, usercoursedto);

            if (usercourse == null) { return BadRequest("This Course is not found"); }

            return Ok(usercourse.toCourseUserDTO());
        }

        [HttpDelete("{CourseId}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserCourse([FromRoute] int CourseId)
        {
            var userId = User.GetUserId();
            var usercourse = await _userCourseRepository.DeleteUserCourse(userId, CourseId);

            if (usercourse == null) { return BadRequest("This Course is Not found"); }

            return Ok(usercourse.toCourseUserDTO());
        }
    }
}
