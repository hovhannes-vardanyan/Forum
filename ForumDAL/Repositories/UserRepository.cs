using ForumDAL.Models;
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
        public UserRepository(ForumContext context)
        {
            this.context = context;

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
        public IList<Post> GetPosts(int user_id)
        {
            return context.Posts.Where(u => u.UserID == user_id).ToList();  
            
        }

        public  List<Notification> ShowNotification(int user_id)
        {
            return context.Notifications.Where(n => n.User_Id == user_id).ToList();
        }

    }
}
