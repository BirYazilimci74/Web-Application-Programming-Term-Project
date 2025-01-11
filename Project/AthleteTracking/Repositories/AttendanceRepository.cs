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
    public class AttendanceRepository
    {
        private readonly DBAthleteTrackingDbContext _context;

        public AttendanceRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Session>> GetAttendedSessionsAsync(Student student)
        {
            var sessions = await _context.SessionAttendances
                .Where(sa => sa.StudentId == student.Id)
                .Select(sa => sa.Session)
                .Include(s => s.Instructor)
                .Include(s => s.Branch)
                .ToListAsync();
            return sessions;
        }

        public void AddAttendance(int sessionId, Student student)
        {
            _context.SessionAttendances.Add(new SessionAttendance
            {
                SessionId = sessionId,
                StudentId = student.Id
            });
            _context.SaveChanges();
        }

        public void RomoveAttendance(int sessionId, Student student)
        {
            var attendance = _context.SessionAttendances
                .FirstOrDefault(sa => sa.SessionId == sessionId && sa.StudentId == student.Id);
            _context.SessionAttendances.Remove(attendance);

            _context.SaveChanges();
        }
    }
}