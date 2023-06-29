using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SchoolResultProject2.Models;

namespace SchoolResultProject2.Repositories
{
    public interface IStudentRepository
    {
        int InsertStudent(Student student);
        Student GetStudentByID(int id);
        Student GetStudentByUserID(int userID);
        List<Student> GetAllStudents();
        int UpdateStudentByID(Student student);
        int DeleteStudentByID(int id);
    }
    public class StudentRepository : IStudentRepository
    {
        string connectionString;
        public StudentRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SchoolResult2ConnectionString"].ConnectionString;
        }
        public int InsertStudent(Student student)
        {
            int row = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var tran = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_crudStudent";
                    cmd.Parameters.AddWithValue("@Option", "InsertStudent");
                    cmd.Parameters.AddWithValue("@RollNo", student.RollNo);
                    cmd.Parameters.AddWithValue("@UserID", student.UserID);
                    cmd.Parameters.AddWithValue("@English", student.English);
                    cmd.Parameters.AddWithValue("@Hindi", student.Hindi);
                    cmd.Parameters.AddWithValue("@Science", student.Science);
                    cmd.Transaction = tran;

                    row = cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
            return row;
        }
        public Student GetStudentByID(int id)
        {
            Student student = new Student();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudStudent";
                cmd.Parameters.AddWithValue("@Option", "GetStudentByID");
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtStudents = new DataTable();

                connection.Open();
                sqlDA.Fill(dtStudents);
                connection.Close();

                if (dtStudents.Rows.Count > 0)
                {
                    DataRow dr = dtStudents.Rows[0];
                    student = new Student
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        RollNo = Convert.ToInt32(dr["RollNo"]),
                        UserID = Convert.ToInt32(dr["UserID"]),
                        English = Convert.ToDecimal(dr["English"]),
                        Hindi = Convert.ToDecimal(dr["Hindi"]),
                        Science = Convert.ToDecimal(dr["Science"])
                    };
                }
            }
            return student;
        }
        public Student GetStudentByUserID(int userID)
        {
            Student student = new Student();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudStudent";
                cmd.Parameters.AddWithValue("@Option", "GetStudentByUserID");
                cmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtStudents = new DataTable();

                connection.Open();
                sqlDA.Fill(dtStudents);
                connection.Close();

                if (dtStudents.Rows.Count > 0)
                {
                    DataRow dr = dtStudents.Rows[0];
                    student = new Student
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        RollNo = Convert.ToInt32(dr["RollNo"]),
                        UserID = Convert.ToInt32(dr["UserID"]),
                        English = Convert.ToDecimal(dr["English"]),
                        Hindi = Convert.ToDecimal(dr["Hindi"]),
                        Science = Convert.ToDecimal(dr["Science"])
                    };
                }
            }
            return student;
        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudStudent";
                cmd.Parameters.AddWithValue("@Option", "GetAllStudents");
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtStudents = new DataTable();

                connection.Open();
                sqlDA.Fill(dtStudents);
                connection.Close();

                foreach(DataRow dr in dtStudents.Rows)
                {
                    students.Add(new Student
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        RollNo = Convert.ToInt32(dr["RollNo"]),
                        UserID = Convert.ToInt32(dr["UserID"]),
                        English = Convert.ToDecimal(dr["English"]),
                        Hindi = Convert.ToDecimal(dr["Hindi"]),
                        Science = Convert.ToDecimal(dr["Science"])
                    });
                }
            }
            return students;
        }
        public int UpdateStudentByID(Student student)
        {
            int row = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var tran = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_crudStudent";
                    cmd.Parameters.AddWithValue("@Option", "UpdateStudentByID");
                    cmd.Parameters.AddWithValue("@ID", student.ID);
                    cmd.Parameters.AddWithValue("@RollNo", student.RollNo);
                    cmd.Parameters.AddWithValue("@UserID", student.UserID);
                    cmd.Parameters.AddWithValue("@English", student.English);
                    cmd.Parameters.AddWithValue("@Hindi", student.Hindi);
                    cmd.Parameters.AddWithValue("@Science", student.Science);
                    cmd.Transaction = tran;

                    row = cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
            return row;
        }
        public int DeleteStudentByID(int id)
        {
            int row = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var tran = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_crudStudent";
                    cmd.Parameters.AddWithValue("@Option", "DeleteStudentByID");
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Transaction = tran;

                    row = cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }
            return row;
        }
    }
}