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
            HttpCookie cookie = Request.Cookies.Get("ID");
            if (cookie!=null  && cookie.Value!="0")
            {
                int loggedInId = Convert.ToInt32(cookie.Value);

                var user = unitOfWork.UserRepository.GetById(loggedInId);
                ViewBag.FullName = user.UserName + " " + user.UserSurname;
                ViewBag.Notifications = unitOfWork.UserRepository.ShowNotification(loggedInId).ToList();
                return View();
            }
            else
            {
                return View();
            }
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