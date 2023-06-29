using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolResultProject2.Models;
using SchoolResultProject2.Repositories;

namespace SchoolResultProject2.Services
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        User GetUserByUsernameAndPassword(string username, string password);
        int DeleteUserByID(int id);
    }
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            user = userRepository.GetUserByUsername(username);

            return user;
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User user = null;
            user = userRepository.GetUserByUsernameAndPassword(username, password);
            
            return user;
        }
        public int DeleteUserByID(int id)
        {
            return userRepository.DeleteUserByID(id);
        }
    }
}