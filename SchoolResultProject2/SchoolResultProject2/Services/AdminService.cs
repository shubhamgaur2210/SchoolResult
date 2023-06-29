using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolResultProject2.Models;
using SchoolResultProject2.Models.ViewModel;
using SchoolResultProject2.Repositories;

namespace SchoolResultProject2.Services
{
    public interface IAdminService
    {
        int InsertAdmin(AdminAddEditViewModel admin);
        AdminViewModel GetAdminByUserID(int userID);
        List<AdminViewModel> GetAllAdmins();
        int UpdateAdmin(AdminAddEditViewModel admin);
    }
    public class AdminService : IAdminService
    {
        IAdminRepository adminRepository;
        IUserRepository userRepository;
        public AdminService()
        {
            adminRepository = new AdminRepository();
            userRepository = new UserRepository();
        }

        public int InsertAdmin(AdminAddEditViewModel admin)
        {
            User u = new User {
                Name = admin.Name,
                Username = admin.Username,
                Password = admin.Password,
                Role = "Admin"
            };
            int row = userRepository.InsertUser(u);
            if (row > 0)
            {
                User user = userRepository.GetUserByUsername(u.Username);
                Admin a = new Admin {
                    Age = admin.Age,
                    UserID = user.ID
                };
                return adminRepository.InsertAdmin(a);
            }
            return 0;
        }
        public AdminViewModel GetAdminByUserID(int userID)
        {
            AdminViewModel admin = null;
            Admin a = adminRepository.GetAdminByUserID(userID);
            if (a != null)
            {
                User u = userRepository.GetUserByID(a.UserID);
                if (u != null)
                {
                    admin = new AdminViewModel
                    {
                        Admin = a,
                        User = u
                    };
                }
            }
            return admin;
        }

        public List<AdminViewModel> GetAllAdmins()
        {
            List<AdminViewModel> admins = new List<AdminViewModel>();
            List<Admin> al = adminRepository.GetAllAdmins();
            foreach (Admin a in al)
            {
                User u = userRepository.GetUserByID(a.UserID);

                admins.Add(new AdminViewModel
                {
                    Admin = a,
                    User = u
                });
            }
            return admins;
        }

        public int UpdateAdmin(AdminAddEditViewModel admin)
        {
            User u = new User {
                ID = admin.UserID,
                Name = admin.Name,
                Username = admin.Username,
                Password = admin.Password,
                Role = admin.Role
            };
            Admin a = new Admin {
                ID = admin.AdminID,
                Age = admin.Age,
                UserID = admin.UserID
            };
            return userRepository.UpdateUserByID(u) + adminRepository.UpdateAdminByID(a);
        }
    }
}