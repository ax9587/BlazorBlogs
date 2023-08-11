using BlazorBlog.Shared;
using BlazorBlog.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users => Set<User>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<UserRole> UserRoles => Set<UserRole>();

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<UserCategory> UserCategorys => Set<UserCategory>();

        public DbSet<Permission> Permissions => Set<Permission>();

        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    }
}
