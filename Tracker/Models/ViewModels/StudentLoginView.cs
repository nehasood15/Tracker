using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Tracker.Models.ViewModels
{
    public class StudentLoginView
    {
        [Key]
        public int studentId { get; set; }
              
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}