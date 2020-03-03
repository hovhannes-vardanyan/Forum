using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{

    class CommentRepository : IMessage<Comment>
    {
        ForumContext commentContext = new ForumContext();
        public Comment GetCommentById(int CommentID)
        {
            try
            {
                var comment = commentContext.Comments.Where(c => c.CommentID == CommentID).First();
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
            commentContext.Comments.Add(comment);
            commentContext.SaveChanges();

        }
        // Edit Comment
        public void Edit(int commentID, Comment msg)
        {
            try
            {
                Comment newComment = msg;
                // Finding Old Comment
                var oldComment = GetCommentById(CommentID);
                // Updating Old Comment
                oldComment.Title = newComment.Title;
                oldComment.Description = newComment.Description;
                oldComment.DateTime = newComment.DateTime;
            }
            catch (InvalidOperationException)
            {
                throw new NotImplementedException();
            }
            commentContext.SaveChanges();
        }
        // Remove Comment      
        public void Delete(int commentID)
        {
            try
            {
                commentContext.Comments.Remove(GetCommentById(commentID));
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            commentContext.SaveChanges();
        }
    }
}
