using AthleteTracking.Data;
using AthleteTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
    }
}