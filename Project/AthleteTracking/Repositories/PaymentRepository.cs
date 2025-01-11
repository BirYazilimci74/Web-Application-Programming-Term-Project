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
    public class PaymentRepository
    {
        private readonly DBAthleteTrackingDbContext _context;

        public PaymentRepository(DBAthleteTrackingDbContext context)
        {
            _context = context;
        }

        public void AddPayment(Student student)
        {
            var payments = CreatePaymentsForAStudent(student);
            foreach (var payment in payments)
            {
                _context.Payments.Add(payment);
            }
            _context.SaveChanges();
        }

        public List<Payment> CreatePaymentsForAStudent(Student student)
        {
            var payments = new List<Payment>();
            var months = new[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };

            for (int i = DateTime.Now.Month; i <= months.Length; i++)
            {
                payments.Add(new Payment
                {
                    Month = months[i-1],
                    DueDate = new DateTime(DateTime.Now.Year, i, 28),
                    Amount = 100,
                    Status = 0,
                    StudentId = student.Id,
                    Student = student
                });
            }

            return payments;
        }

        public async Task<List<Payment>> GetPaymentsForAStudentAsync(int studentId)
        {
            var payments = await _context.Payments.Where(p => p.StudentId == studentId).ToListAsync();
            return payments;
        }

        public async Task PayMonthAsync(int studentId, string month)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.StudentId == studentId && p.Month == month);
            payment.Status = 1;
            await _context.SaveChangesAsync();
        }

    }
}