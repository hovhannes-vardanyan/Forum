using ForumDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final.ViewModels
{
    public class NotificationViewModel
    {
        public List<Notification>  Notifications { get; set; }
        public int Count { get; set; }

    }
}