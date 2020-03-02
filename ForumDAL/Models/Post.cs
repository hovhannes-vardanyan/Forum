using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public class Post : Massage
    {
        public string Description { get; set; }
        public List<Comment> CommentList { get; set; }

        public Post(int postID, string title, int userID, string description) : base(postID, title, userID)
        {
            this.PostID = postID;
            this.Title = title;
            this.UserID = userID;
            this.Description = description;
        }

       


    }
}