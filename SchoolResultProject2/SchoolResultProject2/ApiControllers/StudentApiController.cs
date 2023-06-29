using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolResultProject2.Models.ViewModel;
using SchoolResultProject2.Services;

namespace SchoolResultProject2.ApiControllers
{
    public class StudentApiController : ApiController
    {
        IStudentService studentService;
        public StudentApiController()
        {
            studentService = new StudentService();
        }

        public IHttpActionResult GetStudentByUserID(int id)
        {
            StudentViewModel student = studentService.GetStudentByUserID(id);
            return Json(student);
        }

        public IHttpActionResult GetAllStudentsResult()
        {
            List<StudentViewModel> students = studentService.GetAllStudents().OrderByDescending(temp => temp.TotalMarks).ToList();
            return Json(students);
        }

        public IHttpActionResult GetAllStudents()
        {
            List<StudentViewModel> students = studentService.GetAllStudents();
            return Json(students);
        }
    }
}
