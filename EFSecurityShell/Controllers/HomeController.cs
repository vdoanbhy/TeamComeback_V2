using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamComeback_V2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [PartialCache("1MinuteCache")]
        [ChildActionOnly]
        public PartialViewResult PartialIndexView()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            //int val1 = 42;
            //int val2 = 0;
            //int val3 = val1 / val2;

            //return View(val3);
            ViewBag.message = "your application description page.";
            return View();
        }

        [PartialCache("1MinuteCache")]
        [ChildActionOnly]
        public PartialViewResult PartialAboutView()
        {
            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [PartialCache("1MinuteCache")]
        [ChildActionOnly]
        public PartialViewResult PartialContactView()
        {
            return PartialView();
        }
        public ActionResult Chat()
        {
            return View();
        }
    }
}