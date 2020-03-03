using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public class Comment : Message
    {
        public int CommentID { get; }
        public string Description { get; set; }

        public Comment(int commentID, string title, int userID, int postID, string description) : base(title, userID)
        {
            this.Title = title;
            this.UserID = userID;
            this.PostID = postID;
            this.Description = description;
        }
        public Comment()
        {

        }
    }
}