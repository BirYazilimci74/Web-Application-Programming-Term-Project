using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string District { get; set; }
        
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Phone { get; set; }

        public List<Session> Sessions { get; set; }
    }
}