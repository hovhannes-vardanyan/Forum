using ForumDAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Models.Topics
{
    class MainTopic : ITopic<SubTopic>
    {
        public string TopicName { get; set; }
        public int TopicId { get; set; }
        List<SubTopic> subTopics = new List<SubTopic>();

        public MainTopic()
        {
        }

        public MainTopic(string name, int Id)
        {
            this.TopicName = name;
            this.TopicId = Id;
        }



        public void AddTopic(SubTopic adder)
        {
            subTopics.Add(adder);
        }

        public void RemoveTopic(SubTopic remover)
        {
            subTopics.Remove(remover);
        }
    }
}
