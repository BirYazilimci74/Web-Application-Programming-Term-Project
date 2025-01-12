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
    public class BranchRepository
    {
        private readonly DBAthleteTrackingDbContext _context;

        public BranchRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Branch>> GetBranchsAsync()
        {
            return await _context.Branches.ToListAsync();
        }
    }
}