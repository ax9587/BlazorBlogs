using BlazorBlog.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBlog.Shared
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required,MaxLength(20,ErrorMessage ="Please no more 20 chars")]
        public string Url { get; set; }

        [Required]
        public string Title { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }= DateTime.Now;

        public bool IsPublished { get; set; }

        public  bool IsDeleted { get; set; }

        public int CreatedUserId { get; set; }

        public User CreatedUser { get; set; }

        public Category Category { get; set; }


    }
}