using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            ViewBag.Message = "Instructor Page.";
            ViewBag.UserType = "Instructor";
            ViewBag.UserName = "John Doe(Instructor)";
            return View();
        }
    }
}