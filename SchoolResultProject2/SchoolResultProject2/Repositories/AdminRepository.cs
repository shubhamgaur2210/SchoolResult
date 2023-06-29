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
    public interface IAdminRepository
    {
        int InsertAdmin(Admin student);
        Admin GetAdminByID(int id);
        Admin GetAdminByUserID(int userID);
        List<Admin> GetAllAdmins();
        int UpdateAdminByID(Admin student);
        int DeleteAdminByID(int id);
    }
    public class AdminRepository : IAdminRepository
    {
        string connectionString;
        public AdminRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SchoolResult2ConnectionString"].ConnectionString;
        }
        public int InsertAdmin(Admin admin)
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
                    cmd.CommandText = "usp_crudAdmin";
                    cmd.Parameters.AddWithValue("@Option", "InsertAdmin");
                    cmd.Parameters.AddWithValue("@RollNo", admin.Age);
                    cmd.Parameters.AddWithValue("@UserID", admin.UserID);
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
        public Admin GetAdminByID(int id)
        {
            Admin admin = new Admin();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudAdmin";
                cmd.Parameters.AddWithValue("@Option", "GetAdminByID");
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtAdmins = new DataTable();

                connection.Open();
                sqlDA.Fill(dtAdmins);
                connection.Close();

                if (dtAdmins.Rows.Count > 0)
                {
                    DataRow dr = dtAdmins.Rows[0];
                    admin = new Admin
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        UserID = Convert.ToInt32(dr["UserID"])
                    };
                }
            }
            return admin;
        }
        public Admin GetAdminByUserID(int userID)
        {
            Admin admin = new Admin();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudAdmin";
                cmd.Parameters.AddWithValue("@Option", "GetAdminByUserID");
                cmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtAdmins = new DataTable();

                connection.Open();
                sqlDA.Fill(dtAdmins);
                connection.Close();

                if (dtAdmins.Rows.Count > 0)
                {
                    DataRow dr = dtAdmins.Rows[0];
                    admin = new Admin
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        UserID = Convert.ToInt32(dr["UserID"])
                    };
                }
            }
            return admin;
        }
        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = new List<Admin>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudAdmin";
                cmd.Parameters.AddWithValue("@Option", "GetAllAdmins");
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtAdmins = new DataTable();

                connection.Open();
                sqlDA.Fill(dtAdmins);
                connection.Close();

                foreach (DataRow dr in dtAdmins.Rows)
                {
                    admins.Add(new Admin
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        UserID = Convert.ToInt32(dr["UserID"])
                    });
                }
            }
            return admins;
        }
        public int UpdateAdminByID(Admin admin)
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
                    cmd.CommandText = "usp_crudAdmin";
                    cmd.Parameters.AddWithValue("@Option", "UpdateAdminByID");
                    cmd.Parameters.AddWithValue("@ID", admin.ID);
                    cmd.Parameters.AddWithValue("@Age", admin.Age);
                    cmd.Parameters.AddWithValue("@UserID", admin.UserID);
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
        public int DeleteAdminByID(int id)
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
                    cmd.CommandText = "usp_crudAdmin";
                    cmd.Parameters.AddWithValue("@Option", "DeleteAdminByID");
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