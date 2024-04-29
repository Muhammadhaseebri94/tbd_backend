using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Entity
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Abbreviation { get; set; }
        public string? Picture { get; set; }
        [Required]
        public DateTime DOJ { get; set; }
        public string? Address { get; set; }
        [Required]
        public string CNIC { get; set; }
        public string? BloodGroup { get; set; }
        public string? EmergencyPhoneNumber { get; set; }
        public string? PECNumber { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public override string Email { get; set; }  
        
        [Required(ErrorMessage = "Phone no is required")]
        public override string PhoneNumber { get; set; }   
        
        [Required(ErrorMessage = "Password is required")]
        public override string PasswordHash { get; set; }
        [NotMapped]
        public virtual List<RoleDto> Roles { get; set; }
        //public int ProjectsLateSubmissionCount { get; set; }
        //public int QueryCount { get; set; }
        //public int HolidaysCount { get; set; }
        //public int AverageMonthlyHours { get; set; }
        //public string ManagerMonthlyRemarks { get; set; }
    }
}
