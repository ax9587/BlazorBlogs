using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Shared.Dtos
{
    public class UpdateUserCategoryDto
    {
        public int  UserId { get; set; }
        public IList<UserCategoryDto> UserCategories { get; set; }
    }
}
