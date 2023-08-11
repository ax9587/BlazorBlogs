using Microsoft.AspNetCore.Authorization;

namespace BlazorBlog.Client.Permissions
{
internal class PermissionRequirement : IAuthorizationRequirement
{
    public string strPermission { get; private set; }

    public PermissionRequirement(string permission)
    {
        strPermission = permission;
    }
}
}