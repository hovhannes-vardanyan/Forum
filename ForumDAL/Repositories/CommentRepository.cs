using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{

  public  class CommentRepository : IMessage<Comment>
    {
        ForumContext context;
        public CommentRepository(ForumContext context)
        {
            this.context = context;
        }
        public Comment GetCommentById(int CommentID)
        {
            try
            {
                var comment = context.Comments.Where(c => c.CommentID == CommentID).First();
                return comment;
            }
            catch (InvalidOperationException)
            {
                throw new NotImplementedException();
            }
        }
        // Publish
        public void Publish(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();

        }
        // Edit Comment
        public void Edit(int commentID, Comment msg)
        {
            try
            {
                Comment newComment = msg;
                // Finding Old Comment
                var oldComment = GetCommentById(commentID);
                // Updating Old Comment
                oldComment.Title = newComment.Title;
                oldComment.Description = newComment.Description;
                oldComment.DateTime = newComment.DateTime;
            }
            catch (InvalidOperationException)
            {
                throw new NotImplementedException();
            }
            context.SaveChanges();
        }
        // Remove Comment      
        public void Delete(int commentID)
        {
            try
            {
                context.Comments.Remove(GetCommentById(commentID));
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            context.SaveChanges();
        }
    }
}
