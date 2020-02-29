using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum_Final.Models.Post
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}