using System.Collections.Generic;

namespace BlazorBlog.Client.ViewModel
{
    public class ManageUserRolesViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<UserRolesViewModel> UserRoles { get; set; }
    }
    public class UserRolesViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}
