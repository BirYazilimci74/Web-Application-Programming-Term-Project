using AthleteTracking.Data;
using AthleteTracking.Models;
using AthleteTracking.Repositories;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBAthleteTrackingDbContext _context;
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
        public ActionResult UserRegister(string FullName, string Email, string Password, string ConfirmPassword, string Role, string extraInput)
        {
            if (Password != ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match!";
                return View();
            }

            string passwordHash = Password;

            var user = new User
            {
                Email = Email,
                PasswordHash = passwordHash,
                Role = Role
            };

            if (Role.ToLower().Equals("admin"))
            {
                _adminRepository.AddAdmin(FullName, user);
            }
            else if (Role.ToLower().Equals("student"))
            {
                var student = new Student
                {
                    Name = extraInput,
                    DateOfBirth = DateTime.Now,
                    
                };
                _parentRepository.AddParent(FullName, user, student);
            }
            else if (Role.ToLower().Equals("instructor"))
            {
                _instructorRepository.AddInstructor(FullName, user, extraInput);
            }
            else
            {
                ViewBag.ErrorMessage = "Please select a valide role!!!";
                return View();
            }

            return RedirectToAction("Login");
        }

        public async Task<ActionResult> UserLogin(string email, string password, string role)
        {
            if (role.ToLower().Equals("admin"))
            {
                var admin = await _adminRepository.GetAdminByUserAsync(new User { Email = email, PasswordHash = password });
                Session["Id"] = admin.Id;
                Session["Name"] = admin.Name;
                return RedirectToAction("Admin", "Admin");
            }
            else if (role.ToLower().Equals("student"))
            {
                var student = await _studentRepository.GetStudentByUserAsync(new User { Email = email, PasswordHash = password });
                Session["Id"] = student.Id;
                Session["Name"] = student.Name;
                return RedirectToAction("Student", "Student");
            }
            else if (role.ToLower().Equals("instructor"))
            {
                var instructor = await _instructorRepository.GetInstructorByUserAsync(new User { Email = email, PasswordHash = password });
                Session["Id"] = instructor.Id;
                Session["Name"] = instructor.Name;
                return RedirectToAction("Instructor", "Instructor");
            }
            else
            {
                ViewBag.ErrorMessage = "Please select a valide role!!!";
                return View();
            }
        }
    }
}