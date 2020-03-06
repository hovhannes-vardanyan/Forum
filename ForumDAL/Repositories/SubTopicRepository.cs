using ForumDAL.Models.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
    public class SubTopicRepository
    {
        ForumContext context;
        public SubTopicRepository(ForumContext context)
        {
            this.context = context;
        }
        public SubTopic  GetSubtopicById(int subtopicId)
        {
            var subtopic = context.subTopics.Where(subtopic => subtopic.SubTopicID == subtopicId).First();
            return subtopic;
        }




        public IList<Post> GetPosts(int SubtopicId)
        {
            return context.Posts.Where(subtopic => subtopic.SubtopicID == SubtopicId).ToList();
        }

        //public void AddPosts(Post post, int SubtopicID)
        //{
        //    post.SubtopicID = SubtopicID;
        //    subtopicContext.Posts.Add(post);
        //    subtopicContext.SaveChanges();


        //}

        public void DeleteSubtopic(int subtopicID)
        {

            context.subTopics.Remove(GetSubtopicById(subtopicID));
            context.SaveChanges();
        }
    }
}
