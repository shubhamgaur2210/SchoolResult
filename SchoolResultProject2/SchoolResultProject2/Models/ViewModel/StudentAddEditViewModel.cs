using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SchoolResultProject2.Models.ViewModel
{
    public class StudentAddEditViewModel
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public int StudentID { get; set; }

        [DisplayName("Roll No")]
        public int RollNo { get; set; }

        public decimal English { get; set; }

        public decimal Hindi { get; set; }

        public decimal Science { get; set; }
    }
}