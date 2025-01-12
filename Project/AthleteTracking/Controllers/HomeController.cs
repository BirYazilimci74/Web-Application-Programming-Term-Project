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
                    return View("Register");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                ViewBag.ErrorMessage = "An error occurred while adding the user. Please try again later.";
                return View("Register");
            }

            ViewBag.SuccessMessage = "Registration successful! You can now log in.";
            return View("Login");
        }

        public async Task<ActionResult> UserLogin(string email, string password, string role)
        {
            try
            {
                if (role.ToLower().Equals("admin"))
                {
                    var admin = await _adminRepository.GetAdminByUserAsync(new User { Email = email, PasswordHash = password });
                    if (admin == null) 
                    {
                        ViewBag.ErrorMessage = "Admin not found!";
                        return View("Login");
                    }
                    
                    Session["Id"] = admin.Id;
                    Session["Name"] = admin.Name;
                    Session["Admin"] = admin;
                    Session["UserType"] = "Admin";
                    return RedirectToAction("Index", "Admin");
                }
                else if (role.ToLower().Equals("student"))
                {
                    var parent = await _parentRepository.GetParentByUserAsync(new User { Email = email, PasswordHash = password });
                    if (parent == null)
                    {
                        ViewBag.ErrorMessage = "Parent not found!";
                        return View("Login");
                    }
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
                    if (instructor == null)
                    {
                        ViewBag.ErrorMessage = "Instructor not found!";
                        return View("Login");
                    }

                    Session["Id"] = instructor.Id;
                    Session["Name"] = instructor.Name;
                    Session["Instructor"] = instructor;
                    Session["UserType"] = "Instructor";
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    ViewBag.ErrorMessage = "Please select a valide role!!!";
                    return View("Login");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ViewBag.ErrorMessage = "An error occurred during login. Please try again later.";
                return View("Login");
            }
        }
    }
}