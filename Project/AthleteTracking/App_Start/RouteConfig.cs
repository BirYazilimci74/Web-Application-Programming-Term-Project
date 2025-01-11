using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AthleteTracking
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Register", id = UrlParameter.Optional }
            );

            //Student Routes
            routes.MapRoute(
                name: "Student",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentInstructor",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Instructors", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentPayment",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Payment", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentPayMonth",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "PayMonth", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentInfo",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "UserInfo", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentAttendance",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "MySessions", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentMyRecords",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "MyRecords", id = UrlParameter.Optional }
            );

            //Admin Routes
            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminInfo",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "UserInfo", id = UrlParameter.Optional }
            );

            //Instructor Routes
            routes.MapRoute(
                name: "Instructor",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Instructor", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "InstructorInfo",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Instructor", action = "UserInfo", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "InstructorMyStudents",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Instructor", action = "MyStudents", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "InstructorMySessions",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Instructor", action = "MySessions", id = UrlParameter.Optional }

                );
        }
    }
}
