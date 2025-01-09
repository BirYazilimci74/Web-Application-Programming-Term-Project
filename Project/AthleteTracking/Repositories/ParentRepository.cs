using AthleteTracking.Data;
using AthleteTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AthleteTracking.Repositories
{
    public class ParentRepository
    {
        private readonly DBAthleteTrackingDbContext _context;
        public ParentRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public void AddParent(string name, User user, Student student)
        {
            var parentToAdd = new Parent
            {
                Name = name,
                UserId = user.Id,
                User = user,
                StudentId = student.Id,
                Student = student
            };
            _context.Parents.Add(parentToAdd);
            _context.SaveChanges();
        }
    }
}