using ForumDAL;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Models.Topics
{
    public class SubTopic
    {
        public int SubTopicID { get; set; }
        public string SubtopicName { get; set; }
        public ICollection<Post> posts { get; set; }

        public SubTopic()
        {
        }

        public SubTopic(string name, int Id)
        {
            this.SubtopicName = name;
            this.SubTopicID = Id;
        }
    }
}
