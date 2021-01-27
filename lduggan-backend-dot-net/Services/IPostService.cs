using System;
using lduggan_backend_dot_net.Models;
using lduggan_backend_dot_net.Data;
using System.Collections.Generic;

namespace lduggan_backend_dot_net.Services
{
    public interface IPostService
    {
        public List<Collection> GetCollection();
    }
}
