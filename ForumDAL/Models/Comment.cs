using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public class Comment : Message
    {
        public Comment(int postID, string title, int userID) : base(postID, title, userID)
        {
        }
    }
}