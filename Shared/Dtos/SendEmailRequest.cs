using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Shared.Dtos
{
    public class SendEmailRequest
    {

        [Required, EmailAddress]
        public string From { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string To { get; set; } = string.Empty;
        [Required]
        public string Subject { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;
    }
}
