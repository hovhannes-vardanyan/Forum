using ForumDAL;
using ForumDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum_Final.Controllers
{
    public class SearchController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new ForumContext());

        public ActionResult Search()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Search(string searchString)
        {

            ViewBag.SearchString = searchString;
            return RedirectToAction("SearchResultPage");

        }


        [HttpGet]
        public ActionResult SearchResultPage()
        {
            ViewBag.Result = unitOfWork.SearchRepository.Search(ViewBag.SearchString);
            return View();
        }
    }
}