using ForumDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final.ViewModels
{
    public class PostViewModel
    {
      
        public string postDescription { get; set; }

        public List<Comment> comments { get; set; }
    }
}