using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Specialization { get; set; }
        
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Student> Students { get; set; }
        public List<Session> Sessions { get; set; }
    }
}