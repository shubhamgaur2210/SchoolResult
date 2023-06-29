using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolResultProject2.Models.ViewModel
{
    public class AdminAddEditViewModel
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public int AdminID { get; set; }

        public int Age { get; set; }
    }
}