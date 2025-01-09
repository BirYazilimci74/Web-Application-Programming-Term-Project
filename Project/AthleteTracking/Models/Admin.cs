using System;
using System.ComponentModel.DataAnnotations;

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

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}