using ForumDAL.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
    class MainTopicRepository
    {
        ForumContext maintopicContext = new ForumContext();
      

        public MainTopic GetMainTopic(int topicID)
        {
            var mainTopic = maintopicContext.Topics.Where(maintopic => maintopic.TopicId == topicID).FirstOrDefault();
            return mainTopic;
        }

        //public IList<SubTopic> GetSubTopics(int mainTopicID)
        //{
        //   
        //}

      
        public void AddSubtopic(SubTopic subTopic, int topicID)
        {
            subTopic.SubTopicID = topicID;
            maintopicContext.subTopics.Add(subTopic);
            maintopicContext.SaveChanges();
        }
    }
}
