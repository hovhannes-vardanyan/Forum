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
                UserID = 1


            };
            
           Comment comment = new Comment() 
            {
                UserID =1,
                Title = "First Comment",

            };
            unitOfWork.PostRepository.AddComments(comment,1);
            
            //unitOfWork.PostRepository.Publish(post,1);

            foreach (var item in unitOfWork.SubTopicRepository.GetPosts(1))
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Description);
                foreach (var comment1 in unitOfWork.PostRepository.GetComments(item.PostID))
                {
                    Console.WriteLine(comment1.Title);
                }
            }
           

             

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
