using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Shared.Dtos
{
    public class ResourceRequestDto
    {
        public string UserName { get; set; }
        public string Operation { get; set; }
        public int  ResourceId { get; set; }
        public string  ResourceEnityName { get; set; }
    }
}
