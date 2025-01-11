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
    public class SessionRepository
    {
        private readonly DBAthleteTrackingDbContext _context;

        public SessionRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Session>> GetSessionsForInstructorAsync(int instructorId)
        {
            var sessions = await _context.Sessions
                .Include(s => s.Instructor)
                .Include(s => s.Branch)
                .Where(s => s.InstructorId == instructorId)
                .ToListAsync();
            return sessions;
        }

        public async Task<List<Session>> GetAllSessionsAsync()
        {
            var sessions = await _context.Sessions
                .Include(s => s.Instructor)
                .Include(s => s.Branch)
                .ToListAsync();
            return sessions;
        }
    }
}