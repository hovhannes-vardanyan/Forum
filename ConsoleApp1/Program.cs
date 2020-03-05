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
            PostRepository postRepository = new PostRepository();
            UserRepository repository = new UserRepository();

            Comment comment1 = new Comment()
            {
                Title = "Hi",
                UserID = 8,
            };
            postRepository.AddComments(comment1, 2);
            foreach (var item in repository.GetPosts(7))
            {
                
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Description);
                Console.WriteLine("Comments");
                foreach (var comment in postRepository.GetComments(item.PostID))
                {
                    User user = repository.GetById(comment.UserID);
                    Console.WriteLine("\t"+user.UserName+" "+user.UserSurname );
                    Console.WriteLine($"\t{comment.Title}");
                }
                Console.WriteLine();
            }

            //postRepository.AddComments(new Comment("comm",7),1);

            

        }
    }
}
