using McMaster.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AthleteTracking.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        [AllowedValues("admin","student","instructor")]
        public string Role { get; set; }

    }
}