using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class SessionAttendance
    {
        [Key]
        [Column(Order = 1)]
        public int SessionId { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public int StudentId { get; set; }
        
        public Session Session { get; set; }
        public Student Student { get; set; }
    }
}