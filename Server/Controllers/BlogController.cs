using AutoMapper;
using BlazorBlog.Shared;
using BlazorBlog.Shared.Dtos;
using BlazorBlog.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace BlazorBlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public BlogController(DBContext context)
        {
            _context = context;
            var config = new MapperConfiguration(
                  cfg =>
                  {
                      cfg.CreateMap<BlogPost, BlogPostDto>()
                                 
                                   ;
                  }
                  );

            _mapper = new Mapper(config);
        }
        
        private readonly DBContext context;

        [HttpGet]
        [Route("/api/blog")]
        public ActionResult<List<BlogPostDto>> GetPosts()
        {
            //var posts = _context.BlogPosts;
            //List<BlogPostDto> postDtos = new List<BlogPostDto>();
            //foreach (var post in posts)
            //{
            //    BlogPostDto item = new BlogPostDto();
            //    item.Id = post.Id;
            //    item.DateCreated = post.DateCreated;
            //    item.CreatedUserId = post.CreatedUserId;
            //    item.Url = post.Url;
            //    item.IsPublished = post.IsPublished;
            //    item.Content = post.Content;
            //    item.CreatedUserId=post.CreatedUserId;
            //    item.Description = post.Description;
            //    item.Title = post.Title;
            //    postDtos.Add(item);
            //}
            //return Ok(postDtos);
            return Ok(_context.BlogPosts
                              .Select(post => _mapper.Map<BlogPostDto>(post))
                     );
        }

        [HttpPost]
        [Route("/api/blog")]
        [Authorize]
        public async Task<ActionResult<BlogPost>> CreatePosts(BlogPost request)
        {
            var user=_context.Users.FirstOrDefault(x=>x.Email == this.User.Identity.Name);
            request.CreatedUserId=user.Id;
            var post = _context.Add(request);

            await _context.SaveChangesAsync();
            return request;
        }

        [HttpGet("/api/blog/{url}")]
        public ActionResult<BlogPostDto> GetByUrl(string url)
        {
            //var post= BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            var post = _context.BlogPosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null) return NotFound("Not exist");
            return Ok(_mapper.Map<BlogPostDto>(post));
        }
    }
}
