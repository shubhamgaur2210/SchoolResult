using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolResultProject2.Models.ViewModel
{
    public class StudentViewModel
    {
        public User User { get; set; }
        public Student Student { get; set; }
        public decimal TotalMarks { get
            {
                return Student.English + Student.Hindi + Student.Science;
            } }
        public string Result { get
            {
                if (Student.English < 33 || Student.Hindi < 33 || Student.Science < 33)
                    return "Fail";
                else
                    return "Pass";
            } }
    }
}