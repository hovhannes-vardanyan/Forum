using Forum_Final.Interfaces.Post_Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum_Final.Models.Post
{
    public class Post : Massage, IMassage
    {
        public string Description { get; set; }
        public List<Comment> CommentList { get; set; }

        public Post(int postID, string title, int userID, string description) : base(postID, title, userID)
        {
            this.PostID = postID;
            this.Title = title;
            this.UserID = userID;
            this.Description = description;
        }

        // Remove Post      
        public void Delete(int postID)
        {
            using (PostContext postContext = new PostContext())
            {
                var oldPost = postContext.Posts.Where(p => p.PostID == postID).First();
                postContext.Posts.Remove(oldPost);
                postContext.SaveChanges();
            }
            
        }
        //Edit Post
        public void Edit(int postID, IMassage msg)
        {
            using (PostContext postContext = new PostContext())
            {
                //if IMmasage msg is Post 
                if (msg is Post)
                {
                    //Cast
                    Post newPost = (Post)msg;
                    try
                    {
                        //Finding Old Post
                        var oldPost = postContext.Posts.Where(p => p.PostID == postID).First();
                        // Updating Old Post
                        oldPost.Title = newPost.Title;
                        oldPost.Description = newPost.Description;
                        oldPost.DateTime = newPost.DateTime;
                    }
                    catch (InvalidOperationException)
                    {
                        throw new NotImplementedException();
                    }                                                
                }
                else
                {
                    throw new NotImplementedException();
                }
                postContext.SaveChanges();

            }
        }
        public void Upload(IMassage post)
        {
            using (PostContext postContext = new PostContext())
            {
                if (post is Post)
                {
                    //Casting
                    postContext.Posts.Add(post as Post);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
        public void AddComments(Comment comment)
        {
            CommentList.Add(comment);
        }


    }
}