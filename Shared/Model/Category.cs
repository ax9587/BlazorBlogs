using System;
using System.Collections.Generic;

namespace BlazorBlog.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<UserCategory> UserCategory { get; set; }

    }
}