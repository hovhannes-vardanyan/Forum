using ForumDAL;
using ForumDAL.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final.ViewModels
{
    public class TopicPostsViewModel
    {
        public List<Post> Posts { get; set; }
        public IEnumerable<MainTopic> Topics { get; set; }

        public string TopicName { get; set; }
    }
}