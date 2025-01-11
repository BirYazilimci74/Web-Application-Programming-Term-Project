using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Message = "Admin Page.";
            ViewBag.UserType = "Admin";

            return View();
        }

        public ActionResult UserInfo()
        {
            ViewBag.UserType = "Admin";

            return View();
        }
    }
}