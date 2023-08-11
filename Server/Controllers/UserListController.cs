using AutoMapper;
using BlazorBlog.Client.Pages;
using BlazorBlog.Client.ViewModel;
using BlazorBlog.Shared;
using BlazorBlog.Shared.Dtos;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApplication2.Data;


namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        private readonly DBContext _context;

        private readonly IMapper _mapper;

        public UserListController(DBContext context)
        {
            _context = context;



            var config = new MapperConfiguration(
                   cfg =>
                   {
                       cfg.CreateMap<Role, RoleDto>();
                       cfg.CreateMap<Category, CategoryDto>();
                       cfg.CreateMap<UserCategory, UserCategoryDto>();
                       cfg.CreateMap<RolePermission, RolePermissionDto>();
                       cfg.CreateMap<UserRole, UserRoleDto>()
                                   .ForMember(dest =>
                                                     dest.UserId,
                                                     opt => opt.MapFrom(src => src.User.Id))
                                   .ForMember(dest =>
                                                     dest.RoleId,
                                                     opt => opt.MapFrom(src => src.Role.Id));
                       cfg.CreateMap< User, UserInfoDto>()
                       .ForMember(dest =>
                                                     dest.UserId,
                                                     opt => opt.MapFrom(src => src.Id))
                       .ForMember(dest =>
                                                     dest.Name,
                                                     opt => opt.MapFrom(src => src.Email));
                       cfg.CreateMap<Role, RoleInfoDto>()
                      .ForMember(dest =>
                                                    dest.RoleId,
                                                    opt => opt.MapFrom(src => src.Id))
                      ;
                   }
                   );

            _mapper = new Mapper(config);

        }
        private readonly DBContext context;

        //[Authorize]
        [HttpGet]
        [Route("/api/userlist/users")]
        public ActionResult<List<UserListItemDto>> GetUsers()
        {
            var users = _context.Users;
            List<UserListItemDto> userListItems = new List<UserListItemDto>();
            foreach (var user in users)
            {
                UserListItemDto item= new UserListItemDto();
                item.Id= user.Id;
                item.Email= user.Email;
                userListItems.Add(item);
            }
            return Ok(userListItems);
        }

        #region User-Role
        [HttpGet]
        [Route("/api/userlist/roles")]
        public ActionResult<List<RoleDto>> GetRoles()
        {
            //var roles = _context.Roles;
            //List<RoleDto> roleDtos = new List<RoleDto>();
            //foreach (var role in roles)
            //{
            //    RoleDto item = new RoleDto();
            //    item.Id = role.Id;
            //    item.Name = role.Name;
            //    roleDtos.Add(item);
            //}
            //return Ok(roleDtos);
            return Ok(_context.Roles.Select(role => _mapper.Map<RoleDto>(role)));
        }

        

        [HttpGet("/api/userroles/{userId}")]
        //[Route("/api/userlist/userroles/{userId}")]
        public ActionResult<List<RoleDto>> GetUserRoles(string userId)
        {

            return Ok(_context.UserRoles
                .Where(x=>x.User.Id==int.Parse(userId))
                .Include(x=>x.User)
                .Include(x=>x.Role)
                .Select(userrole => _mapper.Map<UserRoleDto>(userrole)));
        }

       

        [HttpGet]
        [Route("/api/userinfo/{userId}")]
        public ActionResult<UserInfoDto> GetUserInfo(string userId)
        {

            return Ok(_context.Users
                .Where(x => x.Id == int.Parse(userId))
                
                .Select(userinfo => _mapper.Map<UserInfoDto>(userinfo))

                .FirstOrDefault()

                );
        }

        [HttpPost]
        [Route("/api/userroles/update")]
        public async Task<ActionResult<UpdateUserRoleDto>> UpdateUserRoles(UpdateUserRoleDto request)
        {
            var user = await _context.Users
                           .AsNoTracking()
                           .Include(u => u.UserRole)
                           .ThenInclude(ur => ur.Role)
                           .FirstOrDefaultAsync(u => u.Id == request.UserId);
            //Remove the existing user role which is not in the update list
            foreach (var userrole in user.UserRole)
            {
                if (!request.UserRoles.Any(x => x.RoleId == userrole.Id))
                {
                    var ur = _context.UserRoles.FirstOrDefault(x => x.UserId == userrole.UserId && x.RoleId == userrole.RoleId);
                    _context.UserRoles.Remove(ur);
                }
            }
            //Add the new user role which is not in user role entity
            foreach (var userrole in request.UserRoles)
            {
                if (!user.UserRole.Any(x => x.Role.Id == userrole.RoleId))
                {
                    var newUserRole = new UserRole
                    {
                        UserId=request.UserId,
                        RoleId=userrole.RoleId,
                    };
                    _context.UserRoles.Add(newUserRole);
                }
            }
            await _context.SaveChangesAsync();

            return request;
        }
        #endregion User-Role

        #region Role-Permission
        [HttpGet]
        [Route("/api/permissions")]
        public ActionResult<List<RoleDto>> GetPermissions()
        {
            return Ok(_context.Permissions);
        }
        [HttpGet]
        [Route("/api/roleinfo/{roleId}")]
        public ActionResult<UserInfoDto> GetRoleInfo(string roleId)
        {

            return Ok(_context.Roles
                .Where(x => x.Id == int.Parse(roleId))

                .Select(role => _mapper.Map<RoleInfoDto>(role))

                .FirstOrDefault()

                );
        }

        [HttpGet("/api/rolepermissions/{roleId}")]
        public ActionResult<List<RolePermissionDto>> GetRolePermissions(string roleId)
        {

            return Ok(_context.RolePermissions
                .Where(x => x.RoleId == int.Parse(roleId))
                .Select(rolePermission => _mapper.Map<RolePermissionDto>(rolePermission)));
        }

        [HttpPost]
        [Route("/api/rolepermissions/update")]
        public async Task<ActionResult<UpdateRolePermissionDto>> UpdateRolePermissions([FromBody] UpdateRolePermissionDto request)
        {
            var role = await _context.Roles
                           .AsNoTracking()
                           .Include(x=>x.rolepermisssions)
                           .FirstOrDefaultAsync(u => u.Id == request.RoleId);
            //Remove the existing user role which is not in the update list
            foreach (var rolepermission in role.rolepermisssions)
            {
                if (!request.RolePermissions.Any(x => x.PermissionId == rolepermission.PermissionId))
                {
                    var rp = _context.RolePermissions.FirstOrDefault(x => x.RoleId == rolepermission.RoleId && x.PermissionId == rolepermission.PermissionId);
                    _context.RolePermissions.Remove(rp);
                }
            }
            //Add the new user role which is not in user role entity
            foreach (var rolepermission in request.RolePermissions)
            {
                if (!role.rolepermisssions.Any(x => x.PermissionId == rolepermission.PermissionId))
                {
                    var newRolePermission = new RolePermission
                    {
                        PermissionId = rolepermission.PermissionId,
                        RoleId = rolepermission.RoleId,
                    };
                    _context.RolePermissions.Add(newRolePermission);
                }
            }
            await _context.SaveChangesAsync();

            return request;
        }

        #endregion

        #region User-Category
        [HttpGet]
        [Route("/api/Categories")]
        public ActionResult<List<CategoryDto>> GetCategorys()
        {
            return Ok(_context.Categories
                .Select(category => _mapper.Map<CategoryDto>(category)));
        }
        

        [HttpGet("/api/UserCategories/{UserId}")]
        public ActionResult<List<UserCategoryDto>> GetUserCategoriess(string UserId)
        {

            return Ok(_context.UserCategorys
                .Where(x => x.UserId == int.Parse(UserId))
                .Select(UserCategory => _mapper.Map<UserCategoryDto>(UserCategory)));
        }

        [HttpPost]
        [Route("/api/UserCategories/update")]
        public async Task<ActionResult<UpdateUserCategoryDto>> UpdateUserCategorys([FromBody] UpdateUserCategoryDto request)
        {
            var User = await _context.Users
                           .AsNoTracking()
                           .Include(x => x.UserCategory)
                           .FirstOrDefaultAsync(u => u.Id == request.UserId);
            //Remove the existing user User which is not in the update list
            foreach (var UserCategory in User.UserCategory)
            {
                if (!request.UserCategories.Any(x => x.CategoryId == UserCategory.CategoryId))
                {
                    var uc = _context.UserCategorys.FirstOrDefault(x => x.UserId == UserCategory.UserId && x.CategoryId == UserCategory.CategoryId);
                    _context.UserCategorys.Remove(uc);
                }
            }
            //Add the new user User which is not in user User entity
            foreach (var UserCategory in request.UserCategories)
            {
                if (!User.UserCategory.Any(x => x.CategoryId == UserCategory.CategoryId))
                {
                    var newUserCategory = new UserCategory
                    {
                        CategoryId = UserCategory.CategoryId,
                        UserId = UserCategory.UserId,
                    };
                    _context.UserCategorys.Add(newUserCategory);
                }
            }
            await _context.SaveChangesAsync();

            return request;
        }

        #endregion

        #region Grant-Access
        //[Authorize]
        [HttpPost]
        [Route("/api/GrantAccess")]
        public async Task<ActionResult<bool>> GrantAccess(ResourceRequestDto request)
        {
            //Get User
            var User = await _context.Users
                           .AsNoTracking()
            .Include(x => x.UserCategory)
                           .FirstOrDefaultAsync(u => u.Email == request.UserName);
            if (User == null) { return Ok(false); }

            // Get resource by entity and Id'
            if (request.ResourceEnityName == "Blog")
            {
                var blog = await _context.BlogPosts
                            .AsNoTracking()
                            .Include(x => x.CreatedUser)
                            .Include(x=>x.Category)
                            .FirstOrDefaultAsync(u => u.Id == request.ResourceId);
                if (blog == null) { return Ok(false); }
                else
                {
                    if( blog.CreatedUser.Email== request.UserName)
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return Ok(false);

                        //check blog-category-user-category-role-permission
                        
                    }
                }


            }


            return Ok(false);
        }
        #endregion
    }
}
