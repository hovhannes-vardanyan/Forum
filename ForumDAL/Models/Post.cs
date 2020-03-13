using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDAL
{
    public class Post : Message
    {
        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Post(int postID, string title, int userID, string description) : base(title, userID)
        {
            this.Title = title;
            this.UserID = userID;
            this.Description = description;

        }
        public Post()
        {

        }
        public override bool Equals(object other)
        {
            Post post = other as Post;
            if (post == null)
                return false;
            else
            {
                if (this.PostID == post.PostID)
                {
                    return true;
                }
                else
                    return false;

            }
        }

        public override int GetHashCode()
        {
            return this.PostID.GetHashCode();
        }


    }
}