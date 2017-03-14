using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (!object.Equals(Session["UserId"], null))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email, string Password, bool IsRememberMe)
        {
            if (!object.Equals(Session["UserId"], null))
            {
                return RedirectToAction("Index", "Home");
            }
            UserRepository userRepo = new UserRepository();
            bool isError = false;
            string UserId = userRepo.GetUserId(Email);
            if (Email.Trim().Length == 0)
            {
                isError = true;
                ViewBag.EmailError = "Email can't be Empty";
            }
            else if (string.IsNullOrEmpty(UserId))
            {
                isError = true;
                ViewBag.LoginError = "Invalid credentials";
            }
            if (Password.Trim().Length == 0)
            {
                isError = true;
                ViewBag.PasswordError = "Password can't be Empty";
            }
            if (!isError)
            {
                if (!LoginCheck(Password, IsRememberMe, userRepo, UserId))
                {
                    ViewBag.LoginError = "Invalid credentials";
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        private bool LoginCheck(string Password, bool IsRememberMe, UserRepository userRepo, string UserId)
        {
            string encryptedPassword = Convert.ToBase64String(CommonFunctions.Encryption(Password, UserId));
            User usr = userRepo.UserLogin(UserId, encryptedPassword, Request.UserHostAddress);
            if (object.Equals(usr, null))
            {
                return false;
            }
            else
            {
                LoginInfoSaveInSession(usr, IsRememberMe, encryptedPassword);
                return true;
            }
        }

        private void LoginInfoSaveInSession(User usr, bool IsRememberMe, string encryptedPassword)
        {
            Session["Email"] = usr.Email;
            Session["FirstName"] = usr.FirstName;
            Session["LastName"] = usr.LastName;
            Session["User_Unique_Name"] = usr.User_Unique_Name;
            Session["UserId"] = usr.UserId;
            Session["UserType"] = usr.UserType;
            Session["Photo"] = usr.Photo;
            if (IsRememberMe)
            {
                HttpCookie httpUserIdCookie = new HttpCookie("uid", usr.UserId);
                httpUserIdCookie.Expires = DateTime.Now.AddDays(90);
                httpUserIdCookie.Path = "/";

                HttpCookie httpPwdCookie = new HttpCookie("pwd", encryptedPassword);
                httpPwdCookie.Expires = DateTime.Now.AddDays(90);
                httpPwdCookie.Path = "/";

                Response.Cookies.Add(httpUserIdCookie);
                Response.Cookies.Add(httpPwdCookie);
            }
        }
    }
}