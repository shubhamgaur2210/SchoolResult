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
    public interface IUserRepository
    {
        int InsertUser(User user);
        User GetUserByID(int id);
        User GetUserByUsername(string username);
        User GetUserByUsernameAndPassword(string username, string password);
        List<User> GetAllUsers();
        int UpdateUserByID(User user);
        int DeleteUserByID(int id);
    }
    public class UserRepository : IUserRepository
    {
        string connectionString;
        public UserRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SchoolResult2ConnectionString"].ConnectionString;
        }

        public int InsertUser(User user)
        {
            int row = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_crudUser";
                    cmd.Parameters.AddWithValue("@Option", "InsertUser");
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
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
        public User GetUserByID(int id)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudUser";
                cmd.Parameters.AddWithValue("@Option", "GetUserByID");
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtUsers = new DataTable();

                connection.Open();
                sqlDA.Fill(dtUsers);
                connection.Close();

                if (dtUsers.Rows.Count > 0)
                {
                    DataRow dr = dtUsers.Rows[0];
                    user = new User
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Username = Convert.ToString(dr["Username"]),
                        Password = Convert.ToString(dr["Password"]),
                        Role = Convert.ToString(dr["Role"])
                    };
                }
            }
            return user;
        }
        public User GetUserByUsername(string username)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudUser";
                cmd.Parameters.AddWithValue("@Option", "GetUserByUsername");
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtUsers = new DataTable();

                connection.Open();
                sqlDA.Fill(dtUsers);
                connection.Close();

                if (dtUsers.Rows.Count > 0)
                {
                    DataRow dr = dtUsers.Rows[0];
                    user = new User
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Username = Convert.ToString(dr["Username"]),
                        Password = Convert.ToString(dr["Password"]),
                        Role = Convert.ToString(dr["Role"])
                    };
                }
            }
            return user;
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudUser";
                cmd.Parameters.AddWithValue("@Option", "GetUserByUsernameAndPassword");
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtUsers = new DataTable();

                connection.Open();
                sqlDA.Fill(dtUsers);
                connection.Close();

                if (dtUsers.Rows.Count > 0)
                {
                    DataRow dr = dtUsers.Rows[0];
                    user = new User
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Username = Convert.ToString(dr["Username"]),
                        Password = Convert.ToString(dr["Password"]),
                        Role = Convert.ToString(dr["Role"])
                    };
                }
            }
            return user;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_crudUser";
                cmd.Parameters.AddWithValue("@Option", "GetAllUsers");
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable dtUsers = new DataTable();

                connection.Open();
                sqlDA.Fill(dtUsers);
                connection.Close();

                foreach (DataRow dr in dtUsers.Rows)
                {
                    users.Add(new User
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Username = Convert.ToString(dr["Username"]),
                        Password = Convert.ToString(dr["Password"]),
                        Role = Convert.ToString(dr["Role"])
                    });
                }
            }
            return users;
        }
        public int UpdateUserByID(User user)
        {
            int row = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_crudUser";
                    cmd.Parameters.AddWithValue("@Option", "UpdateUserByID");
                    cmd.Parameters.AddWithValue("ID", user.ID);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
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
        public int DeleteUserByID(int id)
        {
            int row = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_crudUser";
                    cmd.Parameters.AddWithValue("@Option", "DeleteUserByID");
                    cmd.Parameters.AddWithValue("ID", id);
                    cmd.Transaction = tran;

                    row = cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
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