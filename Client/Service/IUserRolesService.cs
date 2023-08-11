using BlazorBlog.Client.Pages;
using BlazorBlog.Shared;
using BlazorBlog.Shared.Dtos;
using BlazorBlog.Shared.Models;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Service
{
    public interface IUserRolesService
    {
        Task<List<UserListItemDto>> GetUsers();
        #region User-Role
        Task<UserInfoDto> GetUserInfo(int UserId);

        Task<List<RoleDto>> GetRoles();

        Task<List<UserRoleDto>> GetUserRoles(int UserId);

        Task<UpdateUserRoleDto> UpdateUserRoles(UpdateUserRoleDto userroles);
        #endregion User-Role

        #region Role-Permission
        Task<List<Permission>> GetPermissions();

        Task<List<RolePermissionDto>> GetRolePermissions(int RoleId);

        Task<RoleInfoDto> GetRoleInfo(int RoleId);

        Task<UpdateRolePermissionDto> UpdateRolePermissions(UpdateRolePermissionDto rolepermissions);
        #endregion Role-Permission

        #region User-Category
        Task<List<CategoryDto>> GetCategories();

        Task<List<UserCategoryDto>> GetUserCategories(int UserId);

        Task<UpdateUserCategoryDto> UpdateUserCategories(UpdateUserCategoryDto UserCategorys);
        #endregion User-Category

        bool GrantAccess(ResourceRequestDto request);

    }
}
