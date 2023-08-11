using System;
using System.Collections.Generic;

namespace BlazorBlog.Shared.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<UserRole> roleuser { get; set; }
        public ICollection<RolePermission> rolepermisssions { get; set; }

    }
}