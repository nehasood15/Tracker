using System;
using System.Collections.Generic;
using System.Linq;
using Tracker.Models.DB;
using Tracker.Models.ViewModels;


namespace Tracker.Models.EntityManager
{
    public class ResponseManager
    {
        public List<Question> GetAllQuestions()
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                List<Question> questions = db.Questions.ToList();
                return questions;
            }
        }

        public List<Student> GetAllStudents()
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                List<Student> students = db.Students.ToList();
                return students;
            }
        }
        public void AddStudentResponse2(ListStudentResponsesViewModel responses)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                foreach (StudentResponse sr in responses.Responses)
                {
                    StudentResponse stu = new StudentResponse();
                    stu.questionId = sr.questionId;
                    stu.response = sr.response;
                    stu.studentId = sr.studentId;
                    db.StudentResponses.Add(stu);
                    db.SaveChanges();
                }
            }
        }

        public void AddStudentResponse(List<StudentResponseViewModel> responses)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                foreach (StudentResponseViewModel sr in responses)
                {
                    StudentResponse stu = new StudentResponse();
                    stu.questionId = sr.questionId;
                    stu.response = stu.response;
                    stu.studentId = sr.studentId;
                    db.StudentResponses.Add(stu);
                    db.SaveChanges();
                }
            }
        }
    }
}