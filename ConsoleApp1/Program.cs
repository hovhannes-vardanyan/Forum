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

            Post post = new Post()
            {
                Title = "First Post",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                UserID = 1,

            };
            //postRepository.Publish(post);  
            Comment comment1 = new Comment()
            {
                Title = "Hi",
                UserID = 1,
            };
           postRepository.AddComments(comment1, 1);
            foreach (var item in repository.GetPosts(1))
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
