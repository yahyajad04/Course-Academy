using System.Net;
using System.Net.Mail;

namespace OnlineCourses.Helpers
{
    public class EmailHelper
    {
        private readonly IConfiguration _configuration;
        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtp = _configuration.GetSection("SMTP");

            using var client = new SmtpClient(smtp["Host"], int.Parse(smtp["Port"]))
            {
                Credentials = new NetworkCredential(
                    smtp["Email"],
                    smtp["Password"]),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress("test@mailtrap.io"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            mail.To.Add(toEmail);

            await client.SendMailAsync(mail);

        }
    }
}
