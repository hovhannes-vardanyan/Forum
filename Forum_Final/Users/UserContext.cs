using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final
{
    public class UserContext : DbContext
    {
        public DbSet<Users> dataUsers { get; set; } // creating Db for Users, and using this we can add,delete and save users in our Db
    }
}