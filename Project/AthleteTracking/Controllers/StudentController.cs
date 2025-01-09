using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Student()
        {
            ViewBag.Message = "Student Page.";
            ViewBag.UserType = "Student";
            ViewBag.UserName = "John Doe(Student)";
            return View();
        }
    }
}
