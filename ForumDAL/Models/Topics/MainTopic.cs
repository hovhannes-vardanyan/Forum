using ForumDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Models.Topics
{
  public  class MainTopic
    {
        public string TopicName { get; set; }
        public int MainTopicId { get; set; }
        public ICollection<SubTopic> subtopics { get; set; }

        public MainTopic()
        {
        }

        public MainTopic(string name, int Id)
        {
            this.TopicName = name;
            this.MainTopicId = Id;
        }
    }
}
