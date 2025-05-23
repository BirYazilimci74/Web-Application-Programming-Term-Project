﻿using AthleteTracking.Data;
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
        private readonly DevelopmentRecordRepository _developmentRecordRepository;
        private readonly BranchRepository _branchRepository;

        public InstructorController()
        {
            _context = new DBAthleteTrackingDbContext();
            _sessionRepository = new SessionRepository(_context);
            _studentRepository = new StudentRepository(_context);
            _developmentRecordRepository = new DevelopmentRecordRepository(_context);
            _branchRepository = new BranchRepository(_context);
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

        public ActionResult AddRecord(int studentId, decimal weight, decimal height, string comment)
        {
            decimal bmi = Convert.ToDecimal((double)weight / Math.Pow((double)height / 100.0, 2));
            var record = new DevelopmentRecord
            {
                StudentId = studentId,
                Height = height,
                Weight = weight,
                BMI = bmi,
                CoachComment = comment,
                Date = DateTime.Now
            };
             _developmentRecordRepository.AddDevelopmentRecord(record);

            return RedirectToAction("MyStudents");
        }
        
        public ActionResult AddSession(string day, TimeSpan startTime, TimeSpan endTime, int branchId)
        {
            var instructor = Session["Instructor"] as Instructor;
            var session = new Session
            {
                Day = day,
                Name = instructor.Specialization,
                StartTime = startTime,
                EndTime = endTime,
                BranchId = branchId,
                InstructorId = instructor.Id
            };

            _sessionRepository.AddSession(session);
            return RedirectToAction("MySessions");
        }

        public async Task<ActionResult> CancelSession(int sessionId)
        {
            await _sessionRepository.RemoveSessionAsync(sessionId);
            return RedirectToAction("MySessions");
        }

        public async Task<ActionResult> MySessions()
        {
            var instructor = Session["Instructor"] as Instructor;
            var sessions = await _sessionRepository.GetSessionsForInstructorAsync(instructor.Id);
            Session["Branchs"] = await _branchRepository.GetBranchsAsync();

            return View(sessions);
        }

        
    }
}