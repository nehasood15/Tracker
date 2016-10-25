using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Models.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public int studentId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "University")]
        public string universityName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Role")]
        public string role { get; set; }

        [Display(Name = "ProficiencyId")]
        public int proficiencyId { get; set; }


    }
}