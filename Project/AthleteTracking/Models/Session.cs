using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime StartTime { get; set; }
        
        [Required]
        public DateTime EndTime { get; set; }
        
        [Required]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        
        [Required]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public List<SessionAttendance> Attendances { get; set; }
    }
}