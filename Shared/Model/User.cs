using System;
using System.Collections.Generic;

namespace BlazorBlog.Shared.Models
{
    public class User
    {
        public int Id { get; set; }  //Guid
        public string Email { get; set; } = string.Empty;
        public byte[] passwordHash { get; set; } = new byte[32];
        public byte[] passwordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
        public ICollection<UserCategory> UserCategory { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}