using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolResultProject2.Models;
using SchoolResultProject2.Models.ViewModel;
using SchoolResultProject2.Repositories;

namespace SchoolResultProject2.Services
{
    public interface IStudentService
    {
        int InsertStudent(StudentAddEditViewModel student);
        StudentViewModel GetStudentByUserID(int userID);
        List<StudentViewModel> GetAllStudents();
        int UpdateStudent(StudentAddEditViewModel student);
    }
    public class StudentService : IStudentService
    {
        IStudentRepository studentRepository;
        IUserRepository userRepository;
        public StudentService()
        {
            studentRepository = new StudentRepository();
            userRepository = new UserRepository();
        }

        public int InsertStudent(StudentAddEditViewModel student)
        {
            User u = new User { 
                Name = student.Name,
                Username = student.Username,
                Password = student.Password,
                Role = "Student"
            };
            int row = userRepository.InsertUser(u);
            if (row > 0)
            {   
                User user = userRepository.GetUserByUsername(u.Username);
                Student s = new Student { 
                    RollNo = student.RollNo,
                    UserID = user.ID,
                    English = student.English,
                    Hindi = student.Hindi,
                    Science = student.Science,
                };
                row = studentRepository.InsertStudent(s);
                return row;
            }
            return 0;
        }
        public StudentViewModel GetStudentByUserID(int userID)
        {
            StudentViewModel student = null;
            Student s = studentRepository.GetStudentByUserID(userID);
            if (s != null)
            {
                User u = userRepository.GetUserByID(s.UserID);
                if (u != null)
                {
                    student = new StudentViewModel {
                        User = u,
                        Student = s
                    };
                }
            }
            return student;
        }
        public List<StudentViewModel> GetAllStudents()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();
            List<Student> sl = studentRepository.GetAllStudents();
            foreach (Student s in sl)
            {
                User u = userRepository.GetUserByID(s.UserID);
                students.Add(new StudentViewModel
                {
                    Student = s,
                    User = u
                });
            }
            return students;
        }
        public int UpdateStudent(StudentAddEditViewModel student)
        {
            User u = new User {
                ID = student.UserID,
                Name = student.Name,
                Username = student.Username,
                Password = student.Password,
                Role = student.Role
            };
            Student s = new Student
            {
                ID = student.StudentID,
                RollNo = student.RollNo,
                UserID = student.UserID,
                English = student.English,
                Hindi = student.Hindi,
                Science = student.Science
            };
            return userRepository.UpdateUserByID(u) + studentRepository.UpdateStudentByID(s);
        }
    }
}
