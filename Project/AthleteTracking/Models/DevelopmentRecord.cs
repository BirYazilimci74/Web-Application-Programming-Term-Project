using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class DevelopmentRecord
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Height { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Weight { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal BMI { get; set; }
        public string CoachComment { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}