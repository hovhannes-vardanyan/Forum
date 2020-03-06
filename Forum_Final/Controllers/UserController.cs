using ForumDAL;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum_Final.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ForumContext());
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName,UserSurname,UserLogin,UserPassword")] User user)
        {

            if (ModelState.IsValid)
            {
                unitOfWork.UserRepository.AddUser(user);
                return RedirectToAction("Register");

            }

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {

            if (ModelState.IsValid)
            {
                User signed_user = unitOfWork.UserRepository.SignIn(user.UserLogin, user.UserPassword);

               

                HttpCookie cookie = new HttpCookie("ID");
                cookie.Value = $"{signed_user.UserId}";
                Response.Cookies.Add(cookie);



                return RedirectToAction("Profile", new { id = signed_user.UserId });



            }

            return View();
        }
        [HttpGet]
        public ActionResult Profile(int? id)
        {

            HttpCookie cookie = Request.Cookies.Get("ID");
            int loggedInId = Convert.ToInt32(cookie.Value);
            try
            {

                if (id == loggedInId)
                {
                    User user = unitOfWork.UserRepository.GetById((int)id);
                    ViewBag.Id = loggedInId;
                    
                    ViewBag.Posts = unitOfWork.UserRepository.GetPosts(loggedInId);
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Login");

                }

            }
            catch (NullReferenceException)
            {
                return RedirectToAction("Login");
            }




        }


        public ActionResult SignOut()
        {
            Response.Cookies["ID"].Value = "0";

            return RedirectToAction("Login");

        }
    }
}