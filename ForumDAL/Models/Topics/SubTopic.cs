using ForumDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Models.Topics
{
  public   class SubTopic : ITopic<Post>
    {

        public string SubtopicName { get; set; }
        public int SubTopicID { get; set; }
        List<Post> posts = new List<Post>();

        public SubTopic()
        {
        }

        public SubTopic(string name, int Id)
        {
            this.SubtopicName = name;
            this.SubTopicID = Id;
        }

       

        public void AddTopic(Post adder)
        {
            posts.Add(adder);
        }

        public void RemoveTopic(Post remover)
        {
            posts.Remove(remover);
        }
    }
}
