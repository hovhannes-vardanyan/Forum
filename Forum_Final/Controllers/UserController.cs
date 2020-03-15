using ForumDAL;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAL.Models;

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
                try
                {
                    unitOfWork.UserRepository.AddUser(user);
                    return RedirectToAction("Register");
                }
                catch (Exception)
                {
                    ViewBag.Message = "User with that username already exist ";
                }

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
                try
                {
                    User signed_user = unitOfWork.UserRepository.SignIn(user.UserLogin, user.UserPassword);
                    Response.Cookies["ID"].Value = $"{ signed_user.UserId}";
                    return RedirectToAction("Profile", new { id = signed_user.UserId });
                }
                catch (Exception)
                {
                    ViewBag.Message = "Try again! Something is wrong";
                    return View();
                }                    
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Profile(int? id)
        {
            try
            {
                HttpCookie cookie = Request.Cookies.Get("ID");
                int loggedInId = Convert.ToInt32(cookie.Value);
                User user = unitOfWork.UserRepository.GetById((int)id);
                ViewBag.Id = loggedInId;
                ViewBag.FullName = user.UserName + " " + user.UserSurname;
                ViewBag.Posts = unitOfWork.UserRepository.GetPosts(loggedInId);
                ViewBag.Notifications = unitOfWork.UserRepository.ShowNotification(loggedInId);
                return View(user);
            }
            catch (Exception)
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult Notification() 
        {
            HttpCookie cookie = Request.Cookies.Get("ID");
            int loggedInId = Convert.ToInt32(cookie.Value);
            List<Notification> notifications = unitOfWork.UserRepository.ShowNotification(loggedInId);
            return View(notifications);
        }
        public ActionResult Notifications()
        {
            HttpCookie cookie = Request.Cookies.Get("ID");
            int loggedInId = Convert.ToInt32(cookie.Value);
            User user = unitOfWork.UserRepository.GetById(loggedInId);
            ViewBag.Id = loggedInId;
            ViewBag.FullName = user.UserName + " " + user.UserSurname;
            List<Notification> notifications = unitOfWork.UserRepository.ShowNotification(loggedInId);
            return View(notifications);
        }

        
        public ActionResult Edit()
        {
            HttpCookie cookie = Request.Cookies.Get("ID");
            int loggedInId = Convert.ToInt32(cookie.Value);
            if (loggedInId >0)
            {
                User user = unitOfWork.UserRepository.GetById(loggedInId);
                ViewBag.Id = loggedInId;
                ViewBag.FullName = user.UserName + " " + user.UserSurname;
                ViewBag.Notifications = unitOfWork.UserRepository.ShowNotification(loggedInId);
                return View(user);
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            unitOfWork.UserRepository.Edit(user, user.UserId);
            return View(user);
        }
        public ActionResult SignOut()
        {
            Response.Cookies["ID"].Value = "0";
            return RedirectToAction("Login");

        }

    }
}