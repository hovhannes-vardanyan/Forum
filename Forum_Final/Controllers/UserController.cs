using ForumDAL;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumDAL.Models;
using Forum_Final.ViewModels;
using Microsoft.Ajax.Utilities;

namespace Forum_Final.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ForumContext());

        
        public ActionResult Register()
        {
            if (Session["FullName"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
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
            if (Session["FullName"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
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
                    
                    return RedirectToAction("Index");
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
        public ActionResult Index()
        {
            if (Request.Cookies["ID"].Value != "0")
            {
                HttpCookie cookie = Request.Cookies.Get("ID");
                int loggedInId = Convert.ToInt32(cookie.Value);
                User user = unitOfWork.UserRepository.GetById(loggedInId);
                Session["Id"] = user.UserId;
                Session["FullName"] = user.UserName + " " + user.UserSurname;
                ViewBag.Notifications = unitOfWork.UserRepository.ShowNotification(loggedInId);

                UserViewModel userViewModel = new UserViewModel
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserSurname = user.UserSurname,
                    posts = unitOfWork.UserRepository.GetPosts(user.UserId).ToList(),
                    Topics = unitOfWork.MainTopicRepository.GetTopics()
                };
                ViewBag.Count = unitOfWork.UserRepository.CheckCount(loggedInId);


                return View("Profile",userViewModel);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        public ActionResult Notification() 
        {
            if (Session["FullName"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("ID");
                int loggedInId = Convert.ToInt32(cookie.Value);
                List<Notification> notifications = unitOfWork.UserRepository.ShowNotification(loggedInId);
                int count = 0;
                foreach (var n in notifications)
                {
                    if (!n.Checked)
                    {
                        count++;
                    }
                }
                ViewBag.Count = count;
                return View(notifications);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Notifications()
        {
            if (Session["FullName"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("ID");
                int loggedInId = Convert.ToInt32(cookie.Value);
                User user = unitOfWork.UserRepository.GetById(loggedInId);
                ViewBag.Id = loggedInId;
                ViewBag.FullName = user.UserName + " " + user.UserSurname;
                List<Notification> notifications = unitOfWork.UserRepository.ShowNotification(loggedInId);
               
                return View(notifications);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Edit()
        {

            HttpCookie cookie = Request.Cookies.Get("ID");
            int loggedInId = Convert.ToInt32(cookie.Value);
           if (Session["FullName"] != null)
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
            if (Session["FullName"] != null)
            {
                Response.Cookies["ID"].Value = "0";
                Session["FullName"] = null;
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");

            }
        }
        public PartialViewResult Topics()
        {
            var topics = unitOfWork.MainTopicRepository.GetTopics();
            return PartialView(topics.ToList());
        }
        public ActionResult CheckNotification(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Notification");
            }
            var notification = unitOfWork.UserRepository.GetNotificationById(id);
            unitOfWork.UserRepository.CheckNotification(notification);
            return RedirectToAction("Index","Post",new { id = notification.Post_Id });
        }
    }
}