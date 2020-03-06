using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories
{
   public class UnitOfWork
    {
        UserRepository userRepository;
        PostRepository postRepository;
        CommentRepository commentRepository;
        MainTopicRepository mainTopicRepository;
        SubTopicRepository subTopicRepository;
        ForumContext context;
        public UnitOfWork(ForumContext context)
        {
            this.context =context;
        }
        public CommentRepository CommentRepository 
        { 
            get 
            {
                if (commentRepository == null)
                {
                    commentRepository = new CommentRepository(context);
                }
                return commentRepository;    
            } 
        }
        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }
        public PostRepository PostRepository
        {
            get
            {
                if (postRepository == null)
                {
                    postRepository = new PostRepository(context);
                }
                return postRepository;
            }
        }
        public SubTopicRepository SubTopicRepository
        {
            get
            {
                if (subTopicRepository == null)
                {
                    subTopicRepository = new SubTopicRepository(context);
                }
                return subTopicRepository;
            }
        }
        public MainTopicRepository MainTopicRepository
        {
            get
            {
                if (mainTopicRepository == null)
                {
                    mainTopicRepository = new MainTopicRepository(context);
                }
                return mainTopicRepository;
            }
        }
    }
}
