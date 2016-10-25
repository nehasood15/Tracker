using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tracker.Models.DB;
using System.Collections.Generic;
using Tracker.Models.EntityManager;

namespace Tracker.Models.ViewModels
{
    public class ListStudentResponsesViewModel
    {
        [Key]
        public int? StudentId { get; set; }
        public virtual List<StudentResponse> Responses { get; set; }
        public virtual List<Question> AllQuestions { get; set; }
        public ListStudentResponsesViewModel()
        {
            ResponseManager ResponseManager = new ResponseManager();
            AllQuestions = ResponseManager.GetAllQuestions();

            // run the default empty set, to load empty responses, and then fill it up!!!!

        }
    }
}
