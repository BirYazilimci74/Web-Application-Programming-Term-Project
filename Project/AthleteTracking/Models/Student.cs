using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public List<Payment> Payments { get; set; }
        public List<DevelopmentRecord> DevelopmentRecords { get; set; }
        public List<SessionAttendance> Attendances { get; set; }
    }
}