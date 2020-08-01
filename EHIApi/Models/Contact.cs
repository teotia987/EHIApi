using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EHIApi.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "Please Enter 10 digit Phone No",MinimumLength =10)]
        [RegularExpression("^[0-9]{1,10}$",ErrorMessage ="Enter digits")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Status { get; set; }
    }
    public enum Status
    {
        Active,
        InActive
    }
}