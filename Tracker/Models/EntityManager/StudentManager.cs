using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tracker.Models.DB;
using Tracker.Models.ViewModels;

namespace Tracker.Models.EntityManager
{
    public class StudentManager
    {
       public void AddUserAccount(StudentModel user)
            {

                using (StudentTrackerEntities db = new StudentTrackerEntities())
                {

                    Student stu = new Student();
                    stu.firstName = user.firstName;
                    stu.email = user.email;
                    stu.lastName = user.lastName;
                    stu.password = user.password;
                    stu.universityName = user.universityName;
                    stu.proficiencyId = 2;                
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
    }
    }
