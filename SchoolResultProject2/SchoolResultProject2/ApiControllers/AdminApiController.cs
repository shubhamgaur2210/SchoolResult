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
    public class AdminApiController : ApiController
    {
        IAdminService adminService;
        public AdminApiController()
        {
            adminService = new AdminService();
        }

        public IHttpActionResult GetAdminByUserID(int id)
        {
            AdminViewModel admin = adminService.GetAdminByUserID(id);
            return Json(admin);
        }

        public IHttpActionResult GetAllAdmins()
        {
            List<AdminViewModel> admins =  adminService.GetAllAdmins();
            return Json(admins);
        }
    }
}
