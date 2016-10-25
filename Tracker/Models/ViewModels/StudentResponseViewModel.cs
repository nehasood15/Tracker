using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracker.Models.ViewModels
{
    public class StudentResponseViewModel
    {
        [Key]
        [Column(Order = 0)]
        public int questionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display (Name = "Student Id")]
        public int studentId { get; set; }

        [Display(Name = "Response")]
        public string response { get; set; }

    }
}