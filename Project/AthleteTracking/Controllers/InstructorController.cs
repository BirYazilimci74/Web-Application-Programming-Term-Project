using AthleteTracking.Data;
using AthleteTracking.Models;
using AthleteTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class InstructorController : Controller
    {
        private readonly DBAthleteTrackingDbContext _context;
        private readonly SessionRepository _sessionRepository;
        private readonly StudentRepository _studentRepository;

        public InstructorController()
        {
            _context = new DBAthleteTrackingDbContext();
            _sessionRepository = new SessionRepository(_context);
            _studentRepository = new StudentRepository(_context);
        }

        // GET: Instructor
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult UserInfo()
        {

            return View();
        }

        public async Task<ActionResult> MyStudents()
        {
            var instructor = Session["Instructor"] as Instructor;
            var students = await _studentRepository.GetStudentsByInstructorAsync(instructor.Id);

            return View(students);
        }

        
        

        public async Task<ActionResult> MySessions()
        {
            var instructor = Session["Instructor"] as Instructor;
            var sessions = await _sessionRepository.GetSessionsForInstructorAsync(instructor.Id);
            
            return View(sessions);
        }

        
    }
}