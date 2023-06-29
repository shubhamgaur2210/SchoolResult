using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolResultProject2.Services;
using SchoolResultProject2.Models;
using SchoolResultProject2.Models.ViewModel;

namespace SchoolResultProject2.Controllers
{
    public class AccountController : BaseController
    {
        IUserService us;
        public AccountController()
        {
            this.us = new UserService();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = us.GetUserByUsernameAndPassword(lvm.Username, lvm.Password);
                    if (user != null)
                    {
                        Session["User"] = user;

                        if (user.Role == "Admin")
                            return RedirectToAction("Index", "Admin");
                        else
                            return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        TempData["FailureMessage"] = "Username or Password incorrect";
                        return View(lvm);
                    }
                }
                else
                {
                    TempData["InvalidMessage"] = "Invalid input.";
                    return View(lvm);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(lvm);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}