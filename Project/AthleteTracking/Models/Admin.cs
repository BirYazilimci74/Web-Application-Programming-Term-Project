using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int BrachId { get; set; }
        public Branch Branch { get; set; }
    }
}