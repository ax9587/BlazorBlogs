using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Shared.Dtos
{
    public class UpdateUserRoleDto
    {
        public int  UserId { get; set; }
        public IList<UserRoleDto> UserRoles { get; set; }
    }
}
