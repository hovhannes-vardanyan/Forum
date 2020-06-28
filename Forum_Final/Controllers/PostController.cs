using ForumDAL;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAL.Models;
using Forum_Final.ViewModels;


namespace Forum_Final.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        UnitOfWork unitOfWork = new UnitOfWork(new ForumContext());

        public ActionResult Index(int id)
        {
            if (Request.Cookies["ID"].Value != "0")
            {

                Post posting = unitOfWork.PostRepository.GetPostById(id);
                

                PostViewModel postViewModel = new PostViewModel
                {

                    post = posting,
                    comments = unitOfWork.PostRepository.GetComments(id).ToList()
                    
                };

                return View("PostPage", postViewModel);
            }

            else
            {
                return RedirectToAction("Profile");
            }

        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Posts(int id)
        {
            var posts = unitOfWork.SubTopicRepository.GetPosts(id).ToList();
            var name = unitOfWork.SubTopicRepository.GetSubtopicById(id).SubtopicName;
            TopicPostsViewModel model = new TopicPostsViewModel
            {
                Posts=posts,
                TopicName = name
            };
            return View(model);
        }
        
    }
}