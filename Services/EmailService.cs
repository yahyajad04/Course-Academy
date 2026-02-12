using Microsoft.IdentityModel.Tokens;
using OnlineCourses.DTO_s.AppUser;
using OnlineCourses.Helpers;
using OnlineCourses.Interfaces;
using OnlineCourses.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
namespace OnlineCourses.Services
{

    public class EmailService : IEmailService
    {
        private readonly EmailHelper _emailHelper;
        public EmailService(EmailHelper emailHelper)
        {
            _emailHelper = emailHelper;
        }

        public async Task<bool> VerifyEmail(string email, int? code)
        {
            var subject = "Verify Your Email Address for Online Courses";
            var body = $"You can use this Code to Verify your email: {code.ToString()}";
            if (email.IsNullOrEmpty()) {
                return false;
            }
            await _emailHelper.SendEmailAsync(email, subject, body);
            return true;
        }
    }
}
