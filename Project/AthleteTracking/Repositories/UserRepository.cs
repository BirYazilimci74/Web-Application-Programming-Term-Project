using AthleteTracking.Data;
using AthleteTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AthleteTracking.Repositories
{
    public class UserRepository
    {
        private readonly DBAthleteTrackingDbContext _context;

        public UserRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public void AddUser(string name, string email, string passwordHash, string role)
        {
            var userToAdd = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                Role = role
            };

            _context.Users.Add(userToAdd);

            _context.SaveChanges();
        }
    }
}