using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lduggan_backend_dot_net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lduggan_backend_dot_net.Data;
using lduggan_backend_dot_net.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace lduggan_backend_dot_net.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<Post> _repository;
        private readonly IPostService _postService;
        private IConfiguration _config;

        public PostsController(IRepository<Post> repository, IPostService postService, IConfiguration config)
        {
            _repository = repository;
            _postService = postService;
            _config = config;
        }

        // GET: api/posts
        [HttpGet("Collection")]
        public List<Collection> Get()
        {
            return _postService.GetCollection();
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _repository.Get("posts", id).Result;
        }

        // POST: api/posts
        [HttpPost]
        public Post Add([FromBody] Post post)
        {
            return _repository.Add(post, "posts").Result;
        }

        // PUT: api/posts/5
        [HttpPut("{id}")]
        public Post Put(int id, [FromBody] Post post)
        {
            return _repository.Update(post, "posts", id).Result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id, "posts");
        }

        private bool AuthenticateUser(string token)
        {

            return (token == _config["Jwt:Key"]);
        }
    }
}
