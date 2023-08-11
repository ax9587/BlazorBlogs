using BlazorBlog.Shared.Dtos;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace WebApplication2.Services.Mail
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(SendEmailRequest request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(request.From));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["MailServerStrings:Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["MailServerStrings:Username"], _configuration["MailServerStrings:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
