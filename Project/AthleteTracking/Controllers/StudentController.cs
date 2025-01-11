using AthleteTracking.Data;
using AthleteTracking.Models;
using AthleteTracking.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AthleteTracking.Controllers
{
    public class StudentController : Controller
    {
        private readonly DBAthleteTrackingDbContext _context;
        private readonly InstructorRepository _instructorRepository;
        private readonly PaymentRepository _paymentRepository;
        private readonly SessionRepository _sessionRepository;
        private readonly AttendanceRepository _attendanceRepository;
        private readonly DevelopmentRecordRepository _developmentRecordRepository;
        public StudentController() 
        {
            _context = new DBAthleteTrackingDbContext();
            _instructorRepository = new InstructorRepository(_context);
            _paymentRepository = new PaymentRepository(_context);
            _sessionRepository = new SessionRepository(_context);
            _attendanceRepository = new AttendanceRepository(_context);
            _developmentRecordRepository = new DevelopmentRecordRepository(_context);
        }

        // GET: Student
        public ActionResult Index()
        {
            ViewBag.Message = "Student Page.";

            return View();
        }

        public async Task<ActionResult> Instructors()
        {
            var instructor = await _instructorRepository.GetInstructorsAsync();
            var student = Session["Student"] as Student;
            return View(instructor);
        }

        public async Task<ActionResult> Payment()
        {
            var student = Session["Student"] as Student;
            var payments = await _paymentRepository.GetPaymentsForAStudentAsync(student.Id);
            return View(payments);
        }

        [HttpPost]
        public async Task<JsonResult> PayMonth(string month)
        {
            try
            {
                var student = Session["Student"] as Student;
                await _paymentRepository.PayMonthAsync(student.Id, month);
                return Json(new { success = true, month });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult UserInfo()
        {

            return View();
        }

        public async Task<ActionResult> Sessions()
        {
            var student = Session["Student"] as Student;
            var sessions = await _sessionRepository.GetAllSessionsAsync();
            var attendedSessions = await _attendanceRepository.GetAttendedSessionsAsync(student);

            var unattendedSessions = sessions.Where(s => !attendedSessions.Any(a => a.Id == s.Id)).ToList();

            Session["AttendedSessions"] = attendedSessions;
            Session["UnattendedSessions"] = unattendedSessions;

            return View();
        }

        public async Task<ActionResult> MySessions()
        {
            var student = Session["Student"] as Student;
            var sessions = await _attendanceRepository.GetAttendedSessionsAsync(student);
            return View(sessions);
        }

        public ActionResult MyRecords()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> MyRecordsChart()
        {
            var student = Session["Student"] as Student;
            var data = await _developmentRecordRepository.GetRecordsAsync(student);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
