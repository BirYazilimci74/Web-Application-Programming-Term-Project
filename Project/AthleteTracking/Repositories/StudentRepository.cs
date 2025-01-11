using AthleteTracking.Data;
using AthleteTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace AthleteTracking.Repositories
{
    public class StudentRepository
    {
        private readonly DBAthleteTrackingDbContext _context;
        private readonly PaymentRepository _paymentRepository;

        public StudentRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
            _paymentRepository = new PaymentRepository(_context);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _paymentRepository.AddPayment(student);
            _context.SaveChanges();
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var students = await _context.Students
                .Include(s => s.Instructor)
                .ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Instructor)
                .Include(s => s.DevelopmentRecords)
                .FirstAsync(s => s.Id == id);
            return student;
        }

        public async Task<List<Student>> GetStudentsByInstructorAsync(int instructorId)
        {
            var students = await _context.Students
                .Include(s => s.Instructor)
                .Where(s => s.InstructorId == instructorId)
                .ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByUserAsync(User user)
        {
            var parent = await _context.Parents
                .Include(p => p.Student)
                .FirstOrDefaultAsync(p => p.User.Email == user.Email && p.User.PasswordHash == user.PasswordHash);
            var student = parent.Student;
            return student;
        }
    }
}