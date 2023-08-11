using BlazorBlog.Shared;
using BlazorBlog.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorBlog.Client.Service
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient; 
      

        public BlogService(HttpClient httpClient)  //Control . on selelct of httpClient to create local property // ctor for constructor 
        {
            this._httpClient = httpClient;
        }

        public async Task<BlogPost> CreatePost(BlogPost request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/blog", request);
            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }

        //public BlogPost GetBlogPost(string url)
        public async Task<BlogPostDto> GetBlogPost(string url)
        {
            //return BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            //return await _httpClient.GetFromJsonAsync<BlogPost>($"/api/blog/{url}");

            var result= await _httpClient.GetAsync($"/api/blog/{url}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new BlogPostDto { Title = message, Url = url };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<BlogPostDto>();
            }
         }

        public async Task<List<BlogPostDto>> GetBlogs()
        {
            //return BlogPosts;
            return await _httpClient.GetFromJsonAsync<List<BlogPostDto>>("/api/blog");
        }
    }
}
