using ForumDAL;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum_Final.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ForumContext());
        public ActionResult Index()
        {
            if (Request.Cookies["ID"]==null)
            {
                HttpCookie cookie = new HttpCookie("ID");
                cookie.Value = "0";
                Response.Cookies.Add(cookie);
            }
            if (Request.Cookies["ID"].Value != "0")
            {

                int loggedInId = Convert.ToInt32(Request.Cookies["ID"].Value);

                var user = unitOfWork.UserRepository.GetById(loggedInId);
                ViewBag.FullName = user.UserName + " " + user.UserSurname;
                ViewBag.Notifications = unitOfWork.UserRepository.CheckCount(loggedInId);
            }
            var topics = unitOfWork.MainTopicRepository.GetTopics().ToList();
            return View(topics);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Error()
        {
            return View();
        }     
        public ActionResult Post()
        {
            return View();
        }
    }
}