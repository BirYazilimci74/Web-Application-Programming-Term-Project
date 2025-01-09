using AthleteTracking.Data;
using AthleteTracking.Models;
using System;
using System.Collections.Generic;
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
    }
}