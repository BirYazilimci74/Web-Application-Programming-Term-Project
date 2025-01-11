using AthleteTracking.Data;
using AthleteTracking.Models;
using AthleteTracking.Repositories;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace AthleteTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBAthleteTrackingDbContext _context;
        private readonly AdminRepository _adminRepository;
        private readonly InstructorRepository _instructorRepository;
        private readonly ParentRepository _parentRepository;

        public HomeController()
        {
            _context = new DBAthleteTrackingDbContext();
            _adminRepository = new AdminRepository(_context);
            _instructorRepository = new InstructorRepository(_context);
            _parentRepository = new ParentRepository(_context);
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
        public ActionResult UserRegister(string fullName, string email, string password, string confirmPassword, string role, string extraInput)
        {
            if (password != confirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match!";
                return View();
            }

            string passwordHash = password;

            var user = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                Role = role
            };

            try
            {
                if (role.ToLower().Equals("admin"))
                {
                    _adminRepository.AddAdmin(fullName, user);
                }
                else if (role.ToLower().Equals("student"))
                {
                    _parentRepository.AddParent(fullName, user, extraInput);
                }
                else if (role.ToLower().Equals("instructor"))
                {
                    _instructorRepository.AddInstructor(fullName, user, extraInput);
                }
                else
                {
                    ViewBag.ErrorMessage = "Please select a valide role!!!";
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // TODO: Give alert for not adding the user
                throw;
            }

            return RedirectToAction("Login");
        }

        public async Task<ActionResult> UserLogin(string email, string password, string role)
        {
            try
            {
                if (role.ToLower().Equals("admin"))
                {
                    var admin = await _adminRepository.GetAdminByUserAsync(new User { Email = email, PasswordHash = password });
                    Session["Id"] = admin.Id;
                    Session["Name"] = admin.Name;
                    Session["Admin"] = admin;
                    Session["UserType"] = "Admin";
                    return RedirectToAction("Index", "Admin");
                }
                else if (role.ToLower().Equals("student"))
                {
                    var parent = await _parentRepository.GetParentByUserAsync(new User { Email = email, PasswordHash = password });
                    var student = parent.Student;
                    Session["Id"] = student.Id;
                    Session["Name"] = student.Name;
                    Session["Student"] = student;
                    Session["Parent"] = parent;
                    Session["UserType"] = "Student";
                    return RedirectToAction("Index", "Student");
                }
                else if (role.ToLower().Equals("instructor"))
                {
                    var instructor = await _instructorRepository.GetInstructorByUserAsync(new User { Email = email, PasswordHash = password });
                    Session["Id"] = instructor.Id;
                    Session["Name"] = instructor.Name;
                    Session["Instructor"] = instructor;
                    Session["UserType"] = "Instructor";
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    ViewBag.ErrorMessage = "Please select a valide role!!!";
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // TODO: Give alert for not founding the user
                throw;
            }
        }
    }
}