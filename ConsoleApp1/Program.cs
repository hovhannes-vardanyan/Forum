using ForumDAL;
using ForumDAL.Models.Topics;
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
            //Comment comment = new Comment()
            //{
            //    UserID = 1,
            //    Title = "Hello"
            //};
            //unitOfWork.PostRepository.AddComments(comment,4);



            Console.WriteLine(unitOfWork.UserRepository.ShowNotification(1).Count);
            foreach (var notification in unitOfWork.UserRepository.ShowNotification(1))
            {
                Console.WriteLine(notification.Message);
            }
        }
    }
}
