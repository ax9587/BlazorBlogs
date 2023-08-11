using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Shared.Dtos
{
    public class UpdateRolePermissionDto
    {
        public int  RoleId { get; set; }
        public IList<RolePermissionDto> RolePermissions { get; set; }
    }
}
