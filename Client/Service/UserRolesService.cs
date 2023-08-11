using BlazorBlog.Client.Pages;
using BlazorBlog.Shared;
using BlazorBlog.Shared.Dtos;
using BlazorBlog.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BlazorBlog.Client.Service
{
    public class UserRolesService : IUserRolesService
    {
        private readonly HttpClient _httpClient; 
 

        public UserRolesService(HttpClient httpClient)  
        {
            this._httpClient = httpClient;
        }

        public async Task<List<UserListItemDto>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<UserListItemDto>>("/api/userlist/users");
        }

        #region User-Role
        public async Task<List<RoleDto>> GetRoles()
        {
            //return BlogPosts;
            return await _httpClient.GetFromJsonAsync<List<RoleDto>>("/api/userlist/roles");
        }

        public async Task<List<UserRoleDto>> GetUserRoles(int UserId)
        {
            //return BlogPosts;
            return await _httpClient.GetFromJsonAsync<List<UserRoleDto>>($"/api/userroles/{UserId}");
        }

        public async Task<UserInfoDto> GetUserInfo(int UserId)
        {
            return await _httpClient.GetFromJsonAsync<UserInfoDto>($"/api/userinfo/{UserId}");
        }

        public async Task<UpdateUserRoleDto> UpdateUserRoles(UpdateUserRoleDto userroles)
        {
            var result= await _httpClient.PostAsJsonAsync<UpdateUserRoleDto>($"/api/userroles/update",userroles);
            return await result.Content.ReadFromJsonAsync<UpdateUserRoleDto>();
        }
        #endregion User-Role

        #region Role-Permission
        public async Task<List<Permission>> GetPermissions()
        {
            return await _httpClient.GetFromJsonAsync<List<Permission>>("/api/permissions");
        }

        public async Task<List<RolePermissionDto>> GetRolePermissions(int RoleId)
        {
            //return BlogPosts;
            return await _httpClient.GetFromJsonAsync<List<RolePermissionDto>>($"/api/rolepermissions/{RoleId}");
        }

        public async Task<RoleInfoDto> GetRoleInfo(int RoleId)
        {
            return await _httpClient.GetFromJsonAsync<RoleInfoDto>($"/api/roleinfo/{RoleId}");
        }

        public async Task<UpdateRolePermissionDto> UpdateRolePermissions(UpdateRolePermissionDto rolepermissions)
        {
            var result = await _httpClient.PostAsJsonAsync<UpdateRolePermissionDto>($"/api/rolepermissions/update", rolepermissions);
            return await result.Content.ReadFromJsonAsync<UpdateRolePermissionDto>();
        }
        #endregion Role-Permission

        #region User-Category
        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryDto>>("/api/Categories");
        }

        public async Task<List<UserCategoryDto>> GetUserCategories(int UserId)
        {
            //return BlogPosts;
            return await _httpClient.GetFromJsonAsync<List<UserCategoryDto>>($"/api/UserCategories/{UserId}");
        }

        public async Task<UpdateUserCategoryDto> UpdateUserCategories(UpdateUserCategoryDto UserCategories)
        {
            var result = await _httpClient.PostAsJsonAsync<UpdateUserCategoryDto>($"/api/UserCategories/update", UserCategories);
            return await result.Content.ReadFromJsonAsync<UpdateUserCategoryDto>();
        }
        #endregion User-Category

        public bool GrantAccess(ResourceRequestDto request)
        {

            //var result = await _httpClient.PostAsJsonAsync<ResourceRequestDto>("/api/GrantAccess", request);
            //return await result.Content.ReadFromJsonAsync<bool>();
            

            using (var webrequest = new HttpRequestMessage(HttpMethod.Post, "/api/GrantAccess"))
            {
                var json = JsonSerializer.Serialize(request);
                webrequest.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = _httpClient.Send(webrequest);
                response.EnsureSuccessStatusCode();

                using var streamReader = new StreamReader(response.Content.ReadAsStream());
                var strResponse = streamReader.ReadToEnd();
                if (strResponse == "true")
                {
                    return true;
                }
                //Console.WriteLine(streamReader.ReadToEnd());

                //Note: StreamReader disposes the stream for you
            }

            

            return false;
       }

    }
}
