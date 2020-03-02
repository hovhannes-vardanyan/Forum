using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public class ForumContext : DbContext
    {
        public DbSet<User> usersData { get; set; } // using to save our users in Db
        public DbSet<Post> Posts { get; set; }
    }
}