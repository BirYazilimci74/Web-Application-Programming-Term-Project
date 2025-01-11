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
    public class InstructorRepository
    {
        private readonly DBAthleteTrackingDbContext _context;

        public InstructorRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public void AddInstructor(string name, User user, string specialization)
        {
            var instructorToAdd = new Instructor
            {
                Name = name,
                Specialization = specialization,
                UserId = user.Id,
                User = user,
            };

            _context.Instructors.Add(instructorToAdd);
            _context.SaveChanges();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            var instructor = await _context.Instructors
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.Id == id);
            return instructor;
        }

        public async Task<List<Instructor>> GetInstructorsAsync()
        {
            var instructors = await _context.Instructors
                .Include(i => i.User)
                .ToListAsync();
            return instructors;
        }

        public async Task<Instructor> GetInstructorByUserAsync(User user)
        {
            var instructor = await _context.Instructors
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.User.Email == user.Email && i.User.PasswordHash == user.PasswordHash);
            return instructor;
        }
    }
}