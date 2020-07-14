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
            foreach (var users in context.usersData.ToList())
            {
                if (users.UserLogin == user.UserLogin)
                {
                    throw new Exception();
                }
            }
            context.usersData.Add(user);

            context.SaveChanges();

        }
        public User GetById(int id)
        {
            var user = context.usersData.Where(u => u.UserId == id).FirstOrDefault();
            return user;


        }
        public void Edit(User user,int id)
        {
           User user1 = context.usersData.Where(m => m.UserId == id).FirstOrDefault();
            user1.UserName = user.UserName;
            user1.UserSurname = user.UserSurname;
            user1.UserLogin = user.UserLogin;
            user1.UserPassword = user.UserPassword;
            context.SaveChanges();
            
        }
        public User SignIn(string username, string password)
        {

            var user = context.usersData.Where(u => u.UserLogin == username && u.UserPassword == password).FirstOrDefault();
            if (user !=null)
            {
                return user;

            }
            else
            {
                throw  new NullReferenceException();
            }

        }
        public IList<Post> GetPosts(int user_id)
        {
            return context.Posts.Where(u => u.UserID == user_id).ToList();  
            
        }

        public  List<Notification> ShowNotification(int user_id)
        {
            return context.Notifications.Where(n => n.UserId == user_id).OrderByDescending(n=>n.Id).ToList();
        }
        public int CheckCount(int user_id)
        {
            int c = 0;
            var notifications = ShowNotification(user_id);
            foreach (var item in notifications)
            {
                if (!item.Checked)
                {
                    c++;
                }
            }
            return c;
        }
        public Notification GetNotificationById(int id)
        {
            return context.Notifications.Where(n=>n.Id ==id).FirstOrDefault();
        }
        public void  CheckNotification(Notification notification) 
        {
            notification.Checked = true;
            context.SaveChanges();
        }

    }
}
