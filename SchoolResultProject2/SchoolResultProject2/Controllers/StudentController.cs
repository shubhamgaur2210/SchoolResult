using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolResultProject2.Controllers
{
    public class StudentController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}