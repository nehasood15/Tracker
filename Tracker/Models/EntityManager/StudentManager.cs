using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tracker.Models.DB;
using Tracker.Models.ViewModels;

namespace Tracker.Models.EntityManager
{
    public class StudentManager
    {
        public void AddUserAccount(StudentViewModel user)
        {

            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {

                Student stu = new Student();
                stu.firstName = user.firstName;
                stu.email = user.email;
                stu.lastName = user.lastName;
                stu.password = user.password;
                stu.universityName = user.universityName;
                stu.proficiencyId = 4;
                stu.role = "student";
                db.Students.Add(stu);
                db.SaveChanges();

            }
        }

        public bool IsEmailExisting(string email)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                return db.Students.Where(o => o.email.Equals(email)).Any();
            }
        }

        public string GetUserPassword(string email)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                var user = db.Students.Where(o => o.email.ToLower().Equals(email));
                if (user.Any())
                {
                    return user.FirstOrDefault().password.Trim();
                }
                else
                    return string.Empty;
            }
        }

        public string GetUserRole(string email)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                string role = db.Students.Where(x => x.email.ToLower().Equals(email)).FirstOrDefault().role.ToLower().Trim();
                return role;
            }
        }

        public int GetUserId(string email)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                int id = db.Students.Where(x => x.email.ToLower().Equals(email)).FirstOrDefault().studentId;
                return id;
            }
        }
        public string GetUserProficiencyLevel(string email)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                int id = db.Students.Where(x => x.email.ToLower().Equals(email)).FirstOrDefault().proficiencyId;
                string level = db.ProficiencyLevels.Where(x => x.proficiencyId == id).First().proficiencyLevel.Trim();
                return level;
            }
        }
        public bool IsUserInRole(string email, string roleName)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                Student stu = db.Students.Where(x => x.email.ToLower().Equals(email)).FirstOrDefault();
                if (stu != null && stu.role.ToLower().Trim().Equals(roleName))
                {
                    //change this
                    string roles = stu.role.ToLower();
                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        public void AddStudentProficiencyLevel(int proficiencyLevel , int studentID)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                Student student = db.Students.Where(x => x.studentId == studentID).FirstOrDefault();
                student.proficiencyId = proficiencyLevel;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
