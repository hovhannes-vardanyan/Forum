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
        public ActionResult New(Post post)
        {
            var id = Convert.ToInt32(Request.Cookies["ID"].Value);

            unitOfWork.PostRepository.Publish(post, id);
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult Index(int id, Comment comment)
        {
            //int postID = Convert.ToInt32(Request.Cookies["ID"].Value);
            //var userID = Convert.ToInt32(newComment.UserID);
            //unitOfWork.CommentRepository.Publish(newComment, postID);
            if (ModelState.IsValid)
            {
                unitOfWork.PostRepository.AddComments(comment, id);
            }
            return RedirectToAction("Index", "Post", id);

        }
        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                var post = unitOfWork.PostRepository.GetPostById(id);
                return View(post);
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
            }
            return RedirectToAction("Index", "Post", new { id = id });
        }
        public ActionResult Posts(int id)
        {
            if (Request.Cookies["ID"].Value != "0")
            {
                var posts = unitOfWork.SubTopicRepository.GetPosts(id).ToList();
                var name = unitOfWork.SubTopicRepository.GetSubtopicById(id).SubtopicName;
                TopicPostsViewModel model = new TopicPostsViewModel
                {
                    Posts = posts,
                    TopicName = name
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Profile");
            }
        }
    }
}