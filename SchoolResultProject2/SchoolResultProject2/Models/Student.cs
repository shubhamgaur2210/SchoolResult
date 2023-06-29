using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolResultProject2.Models
{
    public class Student
    {
        public int ID { get; set; }

        public int RollNo { get; set; }

        public decimal English { get; set; }

        public decimal Hindi { get; set; }

        public decimal Science { get; set; }

        public int UserID { get; set; }
    }
}