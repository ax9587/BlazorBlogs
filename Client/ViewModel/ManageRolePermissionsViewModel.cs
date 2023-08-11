using System.Collections.Generic;

namespace BlazorBlog.Client.ViewModel
{
    public class ManageRolePermissionsViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IList<RolePermissionsViewModel> RolePermissions { get; set; }
    }
    public class RolePermissionsViewModel
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public bool Selected { get; set; }
    }
}
