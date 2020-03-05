using ForumDAL.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
    class SubTopicRepository
    {
        ForumContext subtopicContext = new ForumContext();

        public SubTopic  GetSubtopicById(int subtopicId)
        {
            var subtopic = subtopicContext.subTopics.Where(subtopic => subtopic.SubTopicID == subtopicId).First();
            return subtopic;
        }

        


        //public IList<Post> GetPosts (int SubtopicId)
        //{
        //    return subtopicContext.Posts.Where(subtopic => subtopic.SubtopicID == SubtopicId).ToList();
        //}

        //public void AddPosts(Post post, int SubtopicID)
        //{
        //    post.SubtopicID = SubtopicID;
        //    subtopicContext.Posts.Add(post);
        //    subtopicContext.SaveChanges();


        //}

        public void DeleteSubtopic(int subtopicID)
        {

            subtopicContext.subTopics.Remove(GetSubtopicById(subtopicID));
            subtopicContext.SaveChanges();
        }
    }
}
