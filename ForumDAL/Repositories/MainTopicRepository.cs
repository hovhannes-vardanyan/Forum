using ForumDAL.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
    public class MainTopicRepository
    {
        ForumContext context;
        public MainTopicRepository(ForumContext context)
        {
            this.context = context;
        }
      

        public MainTopic GetMainTopic(int topicID)
        {
            var mainTopic = context.Topics.Where(maintopic => maintopic.MainTopicId == topicID).FirstOrDefault();
            return mainTopic;
        }

        //public IList<SubTopic> GetSubTopics(int mainTopicID)
        //{
        //   
        //}

      
        public void AddSubtopic(SubTopic subTopic, int topicID)
        {
            subTopic.SubTopicID = topicID;
            context.subTopics.Add(subTopic);
            context.SaveChanges();
        }
    }
}
