using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public abstract class Massage
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public DateTime DateTime { get => DateTime.Now; set { } }
        public Massage(int postID,string title,int userID)
        {
            this.PostID = postID;
            this.Title = title;
            this.UserID = userID;            
        }

      
    }
}