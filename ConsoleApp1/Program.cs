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
            Comment comment = new Comment()
            {
                UserID = 1,
                Title = "Hello"
            };
            unitOfWork.PostRepository.AddComments(comment, 10);



             Console.WriteLine(unitOfWork.UserRepository.ShowNotification(1).Count);
             foreach (var notification in unitOfWork.UserRepository.ShowNotification(1))
             {
                 Console.WriteLine(notification.Message);
             }
             


            //Post post1 = new Post()
            //{
            //    Title = "c# class constructor with parameters",
            //    Description = "SDasdds",
            //    UserID = 1
            //};
            //Post post2 = new Post()
            //{
            //    Title = "c# class constructor",
            //    Description = "SDasdds",
            //    UserID = 1
            //};
            //Post post3 = new Post()
            //{
            //    Title = "c# class constructor without parameters",
            //    Description = "SDasdds",
            //    UserID = 1
            //};
            //Post post4 = new Post()
            //{
            //    Title = "c# abstract class",
            //    Description = "SDasdds",
            //    UserID = 1


            //};
            //Post post5 = new Post()
            //{
            //    Title = "c# string ",
            //    Description = "SDasdds",
            //    UserID = 1


            //};



            //SubTopic subTopic = new SubTopic(name: "SubTopic1", Id: 1);
            //unitOfWork.SubTopicRepository.AddSubtopics(subTopic);
            //unitOfWork.PostRepository.Publish(post1, 1);
            //unitOfWork.PostRepository.Publish(post2, 1);
            //unitOfWork.PostRepository.Publish(post3, 1);
            //unitOfWork.PostRepository.Publish(post4, 1);
            //unitOfWork.PostRepository.Publish(post5, 1);


            //SearchRepository sr = new SearchRepository();
            //var result = sr.Search(" c#");


            //foreach (var post in result)
            //{
            //    Console.WriteLine(post.Key.Title);
            //}
        }
    }
}
