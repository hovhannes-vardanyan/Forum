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

        public ActionResult Index()
        {
            if (Request.Cookies["ID"].Value != "0")
            {
                HttpCookie cookie = Request.Cookies.Get("ID");

                int postetInID = Convert.ToInt32(cookie.Value);

                Post posting = unitOfWork.PostRepository.GetPostById(postetInID);


                PostViewModel postViewModel = new PostViewModel
                {

                    postDescription = posting.Description,
                    comments = unitOfWork.PostRepository.GetComments(posting.PostID).ToList()
                    
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