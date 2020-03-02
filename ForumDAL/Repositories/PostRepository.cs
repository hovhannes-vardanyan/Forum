using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
    class PostRepository : IMessage
    {
       
        public Post GetPostById(int PostID)
        {
            using (ForumContext postContext = new ForumContext())
            {
                try
                {
                    var post = postContext.Posts.Where(p => p.PostID == PostID).First();
                    return post;
                }
                catch (InvalidOperationException)
                {
                    throw new NotImplementedException();
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }


        }
        // Remove Post      
        public void Delete(int postID)
        {
            using (ForumContext postContext = new ForumContext())
            {
                try
                {
                   postContext.Posts.Remove(GetPostById(postID));
                }
                catch (Exception)
                {
                    throw new NotImplementedException();
                }
                postContext.SaveChanges();
            }

        }
        //Edit Post
        public void Edit(int postID, IMessage msg)
        {
            using (ForumContext postContext = new ForumContext())
            {
                //Cast
                try
                {
                    Post newPost = (Post)msg;
                    //Finding Old Post
                    var oldPost = GetPostById(postID);
                    // Updating Old Post
                    oldPost.Title = newPost.Title;
                    oldPost.Description = newPost.Description;
                    oldPost.DateTime = newPost.DateTime;
                }
                catch (InvalidOperationException)
                {
                    throw new NotImplementedException();
                }
                catch (InvalidCastException)
                {
                    throw new NotImplementedException();
                }
                postContext.SaveChanges();

            }
        }
        public void Publish(IMessage post)
        {
            using (ForumContext postContext = new ForumContext())
            {
                try
                {
                    postContext.Posts.Add(post as Post);
                }
                catch (InvalidCastException)
                {
                    throw new NotImplementedException();
                }

            }
        }
        
        //Add comments into Comment List
        public void AddComments(Comment comment, int postID)
        {
            using (ForumContext postcontext = new ForumContext())
            {
                var post = GetPostById(postID);
                post.CommentList.Add(comment);
                postcontext.SaveChanges();

            }
        }
    }
}
