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

                    postDescription = posting.Description,
                    comments = unitOfWork.PostRepository.GetComments(id).ToList()
                    
                };

                return View("PostPage", postViewModel);
            }

            else
            {
                return RedirectToAction("Profile");
            }

        }
        
    }
}