using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Tracker.Models.DB;

namespace Tracker.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Key]
        public int StudentId { get; set; }
        public List<StudentResponse> Responses { get; set; }
        public List<Question> AllQuestions { get; set; }
    }
}