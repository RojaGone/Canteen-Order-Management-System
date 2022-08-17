using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace canteen_management_system.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult HomeLogin()
        {
           

            return View();
        }
        public ActionResult Homeindex()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult show()
        {
            return View();
        }
        public ActionResult show1()
        {
            return View();
        }
        public ActionResult show2()
        {
            return View();
        }
        public ActionResult show3()
        {
            return View();
        }
        public ActionResult feedback_success()
        {
            return View();
        }
    }
}