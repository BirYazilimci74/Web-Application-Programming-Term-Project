using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class Parent
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public string Phone { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}