using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum_Final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            try
            {
                HttpCookie cookie = Request.Cookies.Get("ID");
                int loggedInId = Convert.ToInt32(cookie.Value);
                if (loggedInId !=0)
                {
                    return RedirectToAction("Profile", "User",new {id = loggedInId });
                }
                else
                {
                    return View();

                }
            }
            catch (Exception)
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