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
    public class DevelopmentRecordRepository
    {
        private readonly DBAthleteTrackingDbContext _context;
        private readonly StudentRepository _studentRepository;

        public DevelopmentRecordRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
            _studentRepository = new StudentRepository(_context);
        }

        public void AddDevelopmentRecord(DevelopmentRecord record)
        {
            _context.DevelopmentRecords.Add(record);
            _context.SaveChanges();
        }

        public async Task<List<DevelopmentRecord>> GetRecordsAsync(Student student)
        {
            var data = await _context.DevelopmentRecords
                .Where(d => d.StudentId == student.Id)
                .OrderBy(d => d.Date)
                .ToListAsync();
            return data;
        }
    }
}