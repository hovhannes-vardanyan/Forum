using ForumDAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
    public class PostRepository : IMessage<Post>
    {
        ForumContext context;
       
        public PostRepository(ForumContext context)
        {
            this.context = context;
        }
        public Post GetPostById(int PostID)
        {

            try
            {
                var post = context.Posts.Where(p => p.PostID == PostID).Include(m=>m.Comments).First();
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
        // Remove Post      
        public void Delete(int postID)
        {

            try
            {
                context.Posts.Remove(GetPostById(postID));
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            context.SaveChanges();

        }
        //Edit Post
        public void Edit(int postID, Post msg)
        {

            try
            {
                Post newPost = msg;
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
            context.SaveChanges();


        }
        public void Publish(Post post, int UserID)
        {
            post.UserID = UserID;
            context.Posts.Add(post);
            context.SaveChanges();

        }
        public IList<Comment> GetComments(int post_id)
        {
            return context.Comments.Where(p => p.PostID == post_id).ToList();
        }

        //Add comments into Comment List
        public void AddComments(Comment comment, int postID, User user_send)
        {

            comment.PostID = postID;
            var post = context.Posts.Where(p => p.PostID == postID).First();
            var user_get = context.usersData.Where(u => u.UserId == post.UserID).First();
            Notification notification = new Notification()
            {
                Message = $"New Comment from {user_send.UserName} in {post.Title} ",
                Post_Id = postID,
                UserId = user_get.UserId,
               

            };
            context.Comments.Add(comment);
            context.SaveChanges();

            notification.CommentID = comment.CommentID;
            if (user_get.UserId != user_send.UserId)
            context.Notifications.Add(notification);
            context.SaveChanges();

        }


    }
}
