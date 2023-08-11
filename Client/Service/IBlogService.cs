using BlazorBlog.Shared;
using BlazorBlog.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Service
{
    public interface IBlogService
    {
        //List<BlogPost> GetBlogs();
        Task<List<BlogPostDto>> GetBlogs();
        //BlogPost GetBlogPost(string url);
        Task<BlogPostDto> GetBlogPost(string url);

        Task<BlogPost> CreatePost(BlogPost post);
    }
}
