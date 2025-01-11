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
    public class ParentRepository
    {
        private readonly DBAthleteTrackingDbContext _context;
        private readonly StudentRepository _studentRepository;
        public ParentRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
            _studentRepository = new StudentRepository(_context);
        }

        public void AddParent(string name, User user, string studentName)
        {
            var studentToAdd = new Student
            {
                Name = studentName,
                DateOfBirth = DateTime.Today,
            };
            _studentRepository.AddStudent(studentToAdd);

            var parentToAdd = new Parent
            {
                Name = name,
                UserId = user.Id,
                User = user,
                StudentId = studentToAdd.Id,
                Student = studentToAdd
            };
            _context.Parents.Add(parentToAdd);
            _context.SaveChanges();
        }

        public async Task<Parent> GetParentByIdAsync(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            return parent;
        }

        public async Task<Parent> GetParentByUserAsync(User user)
        {
            var parent = await _context.Parents
                .Include(p => p.Student)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.User.Email == user.Email && p.User.PasswordHash == user.PasswordHash);
            return parent;
        }
    }
}