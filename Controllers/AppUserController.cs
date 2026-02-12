using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnlineCourses.DTO_s.AppUser;
using OnlineCourses.Extensions;
using OnlineCourses.Interfaces;
using OnlineCourses.Models;

namespace OnlineCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IUserProfileRepository _profileRepository;
        public AppUserController(ITokenService tokenService, UserManager<AppUser> userManager
            , IEmailService emailService, IUserProfileRepository userProfileRepository) { 
            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _profileRepository = userProfileRepository;
        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync(RegisterDTO registordto)
        {
            try
            {
                if (!ModelState.IsValid) { 
                    return BadRequest(ModelState);
                }

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == registordto.Email);

                if (user != null) {
                    return StatusCode(500, "User is already Registered!");
                }

                user = new AppUser
                {
                    Email = registordto.Email,
                    UserName = registordto.UserName,
                    Name = registordto.Name,
                };

                var createdUser = await _userManager.CreateAsync(user, registordto.Password);
                var newprofile = new UserProfile
                {
                    AppUserId = user.Id,
                    AppUser = user,
                };
                var profile = await _profileRepository.CreateProfile(newprofile);

                if (createdUser.Succeeded) {
                    var role = await _userManager.AddToRoleAsync(user, "User");
                    if (role.Succeeded)
                    {
                        user.EmailVerificationCode = new Random().Next(100000, 999999);
                        await _userManager.UpdateAsync(user);
                        var response = await _emailService.VerifyEmail(user.Email, user.EmailVerificationCode);
                        if (response)
                        {
                            return Ok("User Created Successfully, to Login Verify Your Email Please");
                        }
                        else { return BadRequest("Email Didnt get Sent Correctly"); }
                    }
                    else
                    {
                        return StatusCode(500, role.Errors.ToString());
                    }
                }else
                {
                    return StatusCode(500, createdUser.Errors.ToString());
                }
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == registerDTO.Email);

                if (user != null)
                {
                    return StatusCode(500, "User is already Registered!");
                }

                user = new AppUser
                {
                    Email = registerDTO.Email,
                    UserName = registerDTO.UserName,
                    Name = registerDTO.Name,
                };

                var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

                if (createdUser.Succeeded)
                {
                    var role = await _userManager.AddToRoleAsync(user, "Admin");
                    if (role.Succeeded)
                    {
                        user.EmailVerificationCode = new Random().Next(100000, 999999);
                        await _userManager.UpdateAsync(user);
                        var response = await _emailService.VerifyEmail(user.Email, user.EmailVerificationCode);
                        if (response)
                        {
                            return Ok("User Created Successfully, to Login Verify Your Email Please");
                        }
                        else { return BadRequest("Email Didnt get Sent Correctly"); }
                    }
                    else
                    {
                        return StatusCode(500, role.Errors.ToString());
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors.ToString());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("RegisterTeacher")]
        public async Task<IActionResult> RegisterTeacherAsync(RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == registerDTO.Email);

                if (user != null)
                {
                    return StatusCode(500, "User is already Registered!");
                }

                user = new AppUser
                {
                    Email = registerDTO.Email,
                    UserName = registerDTO.UserName,
                    Name = registerDTO.Name,
                };

                var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);
                var newprofile = new TeacherProfile
                {
                    AppUserId = user.Id,
                    AppUser = user,
                };
                var profile = await _profileRepository.CreateProfileTeacher(newprofile);


                if (createdUser.Succeeded)
                {
                    var role = await _userManager.AddToRoleAsync(user, "Teacher");
                    if (role.Succeeded)
                    {
                        user.EmailVerificationCode = new Random().Next(100000, 999999);
                        await _userManager.UpdateAsync(user);
                        var response = await _emailService.VerifyEmail(user.Email, user.EmailVerificationCode);
                        if (response)
                        {
                            return Ok("User Created Successfully, to Login Verify Your Email Please");
                        }
                        else { return BadRequest("Email Didnt get Sent Correctly"); }
                    }
                    else
                    {
                        return StatusCode(500, role.Errors.ToString());
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors.ToString());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(EmailVerifyDTO emaildto)
        {
            var user = await _userManager.FindByEmailAsync(emaildto.Email);

            if (emaildto.Code == user.EmailVerificationCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return Ok("Your Email is Verified Successfully");
            }
            return BadRequest("Email/User Not Correct");
        }
        [HttpPost("GetVerificationCode")]
        public async Task<IActionResult> GetCode(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            user.EmailVerificationCode = new Random().Next(100000, 999999);
            await _userManager.UpdateAsync(user);

            var response = await _emailService.VerifyEmail(Email, user.EmailVerificationCode);
            if (!response)
                return StatusCode(500, "An Error Occured");
            return Ok("Email Sent Successfully");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDTO logindto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var user = await _userManager.FindByEmailAsync(logindto.Email);
                if (user == null) {
                    return StatusCode(500, "Login Failed!");
                }

                if (!user.EmailConfirmed) {
                    return BadRequest("Please verify your email to login.");
                }
                var isCorrect = await _userManager.CheckPasswordAsync(user, logindto.Password);
                if (isCorrect)
                {
                    return Ok(new GetLoginDTO
                    {
                        WelcomeString = $"Welcome to the Online Courses Site {user.UserName}",
                        Token = await _tokenService.GetToken(user)

                    }
                    );
                } else
                {
                    return StatusCode(500, "Login Failed");
                }
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
