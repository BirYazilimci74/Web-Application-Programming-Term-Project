using AthleteTracking.Data;
using AthleteTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;

namespace AthleteTracking.Repositories
{
    public class AdminRepository
    {
        private readonly DBAthleteTrackingDbContext _context;
        public AdminRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Admin>> GetAdminsAsync()
        {
            var admins = await _context.Admins
                .Include(a => a.User)
                .ToListAsync();
            return admins;
        }

        public void AddAdmin(string name, User user)
        {
            try
            {
                var adminToAdd = new Admin
                {
                    Name = name,
                    UserId = user.Id,
                    User = user,
                };

                _context.Admins.Add(adminToAdd);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            var admin = await _context.Admins
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
            return admin;
        }

        public async Task<Admin> GetAdminByUserAsync(User user)
        {
            var admin = await _context.Admins
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => ((a.User.Email == user.Email) && (a.User.PasswordHash == user.PasswordHash)));
            return admin;
        }
    }
}