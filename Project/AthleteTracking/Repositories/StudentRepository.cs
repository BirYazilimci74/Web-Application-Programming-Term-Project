using AthleteTracking.Data;
using AthleteTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace AthleteTracking.Repositories
{
    public class StudentRepository
    {
        private readonly DBAthleteTrackingDbContext _context;
        public StudentRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return student;
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