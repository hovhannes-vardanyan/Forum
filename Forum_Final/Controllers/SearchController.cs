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
        public ActionResult Search([Bind(Include = "searchString")]string searchString)
        {

            return RedirectToAction("SearchResultPage",new {q = searchString });

        }


        [HttpGet]
        public ActionResult SearchResultPage(string q)
        {
            ViewBag.Result = unitOfWork.SearchRepository.Search(q);
            return View();
        }
    }
}