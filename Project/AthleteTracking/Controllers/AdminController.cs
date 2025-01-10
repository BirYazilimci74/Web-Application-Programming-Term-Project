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
        public ActionResult Admin()
        {
            ViewBag.Message = "Admin Page.";
            ViewBag.UserType = "Admin";
            ViewBag.UserName = Session["Name"]?.ToString();
            return View();
        }
    }
}