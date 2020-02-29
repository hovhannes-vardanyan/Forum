using Forum_Final.Interfaces.Post_Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final.Models
{
    public class Post : IMassage
    {
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
        public List<Comment> CommentList { get; set; }
        public DateTime DateTime { get; set; }
        //public int Raiting { get; set; }


    }
}