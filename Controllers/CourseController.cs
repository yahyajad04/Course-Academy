using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourses.DTO_s.Courses;
using OnlineCourses.Extensions;
using OnlineCourses.Interfaces;
using OnlineCourses.Mappers;
using OnlineCourses.Models;
using System.Runtime.InteropServices;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly UserManager<AppUser> _userManager;
        public CourseController(ICourseRepository courseRepo, UserManager<AppUser> userManager) { 
            _courseRepo = courseRepo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepo.GetAllAsync();
            var coursesdto = courses.Select(c => c.toCourseDTO()).ToList();

            return Ok(coursesdto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseByID([FromRoute] int id)
        {
            var course = await _courseRepo.GetByIdAsync(id);
            if (course == null) {
                return NotFound("This Course Doesnt Exist");
            }

            return Ok(course.toCourseDTO());
        }

        [HttpPost]
        [Authorize(Roles ="Teacher")]
        public async Task<IActionResult> CreateCourse(CreateCourseDTO coursedto)
        {
            var userId = User.GetUserId();
            var user = await _userManager.Users.Include(p => p.Teacher).FirstOrDefaultAsync(u => u.Id == userId);
            coursedto.TeacherProfileId = user.Teacher.Id;
            var course = await _courseRepo.CreateAsync(coursedto);
            if (course == null) {
                return BadRequest("Category for this course doesnt exist");
            }
            return Ok(course.toCourseDTO());
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> EditCourse([FromRoute] int id, [FromBody]EditCourseDTO coursedto)
        {
            var course = await _courseRepo.EditAsync(id, coursedto);
            if (course == null) {
                return NotFound("This Course doesnt exist");
            }

            return Ok(course.toCourseDTO());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Teacher")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            var course = await _courseRepo.DeleteAsync(id);
            if (course == null)
            {
                return NotFound("This Course Doesnt Exist");
            }
            return Ok(course.toCourseDTO());
        }
    }
}
