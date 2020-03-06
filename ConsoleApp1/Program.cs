using ForumDAL;
using ForumDAL.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            UnitOfWork unitOfWork = new UnitOfWork(new ForumContext());
            //Publishing Post
            Post post = new Post()
            {
                Title = "My First Post",
                Description = "SDasdds",
                UserID = 7


            };

            unitOfWork.PostRepository.Publish(post,2);
            unitOfWork.SubTopicRepository.GetPosts(7);

             //Adding comment
            /*Comment comment = new Comment() 
            {
                UserID =1,
                Title = "First Comment",

            };
            unitOfWork.PostRepository.AddComments(comment,1);
            */

            //Geting Posts
            //foreach (var post in unitOfWork.UserRepository.GetPosts(1))
            //{
            //    Console.WriteLine(post.Title);
            //    Console.WriteLine(post.Description);
            //    foreach (var comment in unitOfWork.PostRepository.GetComments(post.PostID))
            //    {
            //        Console.WriteLine("\t"+comment.Title);
            //    }
            //}




        }
    }
}
