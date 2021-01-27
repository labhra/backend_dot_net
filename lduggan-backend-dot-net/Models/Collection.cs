using System;
using System.Collections.Generic;

namespace lduggan_backend_dot_net.Models
{
    public class Collection
    {
        public Post Post { get; set; }
        public Album Album { get; set; }
        public User User { get; set; }
    }
}
