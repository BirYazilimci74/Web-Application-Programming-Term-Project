using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Student()
        {
            ViewBag.Message = "Student Page.";
            ViewBag.UserType = "Student";
            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Admin Page.";
            ViewBag.UserType = "Admin";
            return View();
        }

        public ActionResult Instructor()
        {
            ViewBag.Message = "Instructor Page.";
            ViewBag.UserType = "Instructor";
            return View();
        }
    }
}