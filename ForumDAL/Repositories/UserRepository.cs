using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
  public class UserRepository
    {
        ForumContext context;
        public UserRepository()
        {
            context = new ForumContext();
        }

        public void AddUser(User user)
        {
            context.usersData.Add(user);

            context.SaveChanges();

        }
        public User GetById(int id)
        {
            var user = context.usersData.Where(u => u.UserId == id).FirstOrDefault();
            return user;


        }
        public User SignIn(string username, string password)
        {
            var user = context.usersData.Where(u => u.UserLogin == username && u.UserPassword == password).FirstOrDefault();
            return user;

        }
        

    }
}
