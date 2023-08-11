
using BlazorBlog.Client.Service;
using BlazorBlog.Shared.Dtos;
using Bunit.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace  BlazorBlog.Client.Permissions
{
internal class PermissionAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, object>
{
        private readonly IUserRolesService _userRolesService;
        public PermissionAuthorizationHandler(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, object resource)
        {
            if (context.User.Identity.Name.IsNullOrEmpty() )
            {
               
               return Task.CompletedTask;
            }
            //var permissionss = context.User.Claims.Where(x => x.Type == "Permission" &&
            //                                                x.Value == requirement.strPermission &&
            //                                                x.Issuer == "LOCAL AUTHORITY");
            //if (permissionss.Any())
            //{
            //    context.Succeed(requirement);  
            //}
            //Call api bool GrantAccess(UserId,BlogId,permission)
            ResourceRequestDto request = new ResourceRequestDto()
            {

            };
           //var granted = _userRolesService.GrantAccess(request);
           //if (granted)
           // {
           //     context.Succeed(requirement);
           //     return Task.CompletedTask;
           // }
            return Task.CompletedTask;


        }

    }
}