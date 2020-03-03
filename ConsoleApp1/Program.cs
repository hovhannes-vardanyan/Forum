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

            postRepository.Publish(new Post(14,"Hello World",7,"Sdsadasd"));

            postRepository.AddComments(new Comment("comm",7),14);



        }
    }
}
