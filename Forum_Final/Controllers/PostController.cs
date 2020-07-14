using ForumDAL;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAL.Models;
using Forum_Final.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http;

namespace Forum_Final.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        UnitOfWork unitOfWork = new UnitOfWork(new ForumContext());

        public ActionResult Index(int id)
        {
           

                Post posting = unitOfWork.PostRepository.GetPostById(id);


                PostViewModel postViewModel = new PostViewModel
                {

                    post = posting,
                    comments = unitOfWork.PostRepository.GetComments(id).ToList()

                };
            foreach (var comment in postViewModel.comments)
            {
                comment.UserName = unitOfWork.UserRepository.GetById(comment.UserID).UserLogin;
            }
            if (Request.Cookies["ID"].Value != "0")
            {
                
                if (postViewModel.post.UserID == Convert.ToInt32(Request.Cookies["ID"].Value))
                {
                    return View("PostPageAdmin", postViewModel);

                }

                return View("PostPage", postViewModel);
            }

            else
            {
                return View("PostPageGuest",postViewModel);
            }

        }
        public ActionResult New()
        {
            if (Request.Cookies["ID"].Value != "0")
            {
                var topics = unitOfWork.MainTopicRepository.GetTopics();
                ViewBag.Topics = topics;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Post post)
        {
            var id = Convert.ToInt32(Request.Cookies["ID"].Value);
            if (!ModelState.IsValid)
            {
                var topics = unitOfWork.MainTopicRepository.GetTopics();
                ViewBag.Topics = topics;
                return View(post);
             
            }
            unitOfWork.PostRepository.Publish(post, id);
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult Index(int id, Comment comment)
        {
            comment.UserID = Convert.ToInt32(Request.Cookies["ID"].Value);
            var user = unitOfWork.UserRepository.GetById(comment.UserID);
            if (ModelState.IsValid)
            {
                unitOfWork.PostRepository.AddComments(comment, id,user);
            }
            return RedirectToAction("Index", "Post", id);

        }
        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                var post = unitOfWork.PostRepository.GetPostById(id);
                if (post.UserID == Convert.ToInt32(Request.Cookies["ID"].Value))
                {
                    return View(post);
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Post", new { id = id });
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Post post)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PostRepository.Edit(id, post);
                return RedirectToAction("Index", "Post", new { id = id });

            }
            return View(post);
        }
        public ActionResult Posts(int id)
        {
           
                var posts = unitOfWork.SubTopicRepository.GetPosts(id).ToList();
                var name = unitOfWork.SubTopicRepository.GetSubtopicById(id).SubtopicName;
                TopicPostsViewModel model = new TopicPostsViewModel
                {
                    Posts = posts,
                    TopicName = name,
                    Topics = unitOfWork.MainTopicRepository.GetTopics().ToList()

                };
                return View(model);
           
        }
    }
}