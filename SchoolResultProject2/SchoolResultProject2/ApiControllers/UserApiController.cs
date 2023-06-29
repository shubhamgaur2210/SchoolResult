using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolResultProject2.Models;
using SchoolResultProject2.Services;

namespace SchoolResultProject2.ApiControllers
{
    public class UserApiController : ApiController
    {
        IUserService userService;
        public UserApiController()
        {
            userService = new UserService();
        }

        public IHttpActionResult DeleteUserByID(int id)
        {
            userService.DeleteUserByID(id);
            return Json("");
        }
    }
}
