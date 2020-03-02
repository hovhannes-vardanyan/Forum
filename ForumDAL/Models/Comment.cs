using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public class Comment : Message
    {
        public int CommentId { get; set; }
        public Comment(int postID, string title, int userID) : base(title, userID)
        {
        }
    }
}