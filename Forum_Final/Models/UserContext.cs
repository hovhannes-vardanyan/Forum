//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum_Final.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> usersData { get; set; } // using to save our users in Db
    }
}