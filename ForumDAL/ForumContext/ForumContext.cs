using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ForumDAL.Models.Topics;

namespace ForumDAL
{
    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("Forum")
        {

        }
        public DbSet<User> usersData { get; set; } 
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<MainTopic> Topics{ get; set; }

        public DbSet<SubTopic> subTopics{ get; set; }
    }
}