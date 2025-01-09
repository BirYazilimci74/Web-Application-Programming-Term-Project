using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Month { get; set; }
        
        [Required]
        public DateTime DueDate { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Amount { get; set; } = decimal.Zero;
        
        [Required]
        public byte Status { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}