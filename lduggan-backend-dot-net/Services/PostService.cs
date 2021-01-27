using System;
using lduggan_backend_dot_net.Models;
using lduggan_backend_dot_net.Data;
using System.Collections.Generic;
using System.Collections;

namespace lduggan_backend_dot_net.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repository;
        public PostService(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public List<Collection> GetCollection()
        {
            var posts = _repository.GetAll<Post>("posts").Result;
            var users = _repository.GetAll<User>("users").Result;
            var albums = _repository.GetAll<Album>("albums").Result;

            var returnCollection = new List<Collection>(30);

            return returnCollection;
        }
    }

    
}