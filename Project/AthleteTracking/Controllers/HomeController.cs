using AthleteTracking.Data;
using AthleteTracking.Models;
using AthleteTracking.Repositories;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class HomeController : Controller
    {
        private DBAthleteTrackingDbContext _context;
        private readonly AdminRepository _adminRepository;
        private readonly InstructorRepository _instructorRepository;
        private readonly ParentRepository _parentRepository;
        private readonly StudentRepository _studentRepository;
        private readonly UserRepository _userRepository;

        public HomeController()
        {
            _context = new DBAthleteTrackingDbContext();
            _adminRepository = new AdminRepository(_context);
            _instructorRepository = new InstructorRepository(_context);
            _parentRepository = new ParentRepository(_context);
            _studentRepository = new StudentRepository(_context);
            _userRepository = new UserRepository(_context);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string FullName, string Email, string Password, string ConfirmPassword, string Role)
        {
            if (Password != ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match!";
                return View();
            }

            string passwordHash = Crypto.HashPassword(Password);

            var user = new User
            {
                Email = Email,
                PasswordHash = passwordHash,
                Role = Role
            };

            var userRepo = new UserRepository(new DBAthleteTrackingDbContext());


            if (Role.ToLower().Equals("admin"))
            {
                _adminRepository.AddAdmin(FullName, user);
            }
            else if (Role.ToLower().Equals("student"))
            {
                _parentRepository.AddParent(FullName, user);
            }
            else if (Role.ToLower().Equals("instructor"))
            {
                _instructorRepository.AddInstructor(FullName, user, "General");
            }
            else
            {
                ViewBag.ErrorMessage = "Please select a valide role!!!";
                return View();
            }

            return RedirectToAction("Login");

        }
    }
}