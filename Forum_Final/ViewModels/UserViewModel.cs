using ForumDAL;
using ForumDAL.Models;
using ForumDAL.Models.Topics;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final.ViewModels
{
    //Class for passing multiple models
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }

        public string UserLogin { get; set; }
      
        public string UserPassword { get; set; }

        public List<Post> posts { get; set; }
        public List<Notification> Notifications { get; set; }
        public IEnumerable<MainTopic> Topics{ get; set; }


    }
}