using ForumDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final.ViewModels
{
    public class PostViewModel
    {
      
        public Post post { get; set; }

        public List<Comment> comments { get; set; }
        public string UserName { get; set; }
        public string CommentTitle { get; set; }
    }
}