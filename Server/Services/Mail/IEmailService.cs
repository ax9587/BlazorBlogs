using BlazorBlog.Shared.Dtos;

namespace WebApplication2.Services.Mail
{
    public interface IEmailService
    {
        void SendEmail(SendEmailRequest request);
    }
}
