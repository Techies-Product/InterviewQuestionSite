using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            CountryRepository cr = new CountryRepository();
            ViewBag.Countries = cr.Countries;
            return View();
        }

        [HttpPost]
        public string Index(User model)
        {
            if (ValidateRegistrationData(model))
            {
                UserRepository userRepo = new UserRepository();
                if (!string.IsNullOrEmpty(userRepo.GetUserId(model.Email)))
                {
                    return "This Email Id Already Exists";
                }
                model.UserId = CommonFunctions.GetUserId();
                model.RegistrationIpAddress = Request.UserHostAddress;

                model.Password = Convert.ToBase64String(CommonFunctions.Encryption(model.Password, model.UserId));
                model.FacebookAccessToken = object.Equals(model.FacebookAccessToken, null) ? "" : model.FacebookAccessToken;
                model.FacebookProfile = object.Equals(model.FacebookProfile, null) ? "" : model.FacebookProfile;
                model.GoogleAccessToken = object.Equals(model.GoogleAccessToken, null) ? "" : model.GoogleAccessToken;
                model.GoogleProfile = object.Equals(model.GoogleProfile, null) ? "" : model.GoogleProfile;
                model.TwitterHandle = object.Equals(model.TwitterHandle, null) ? "" : model.TwitterHandle;
                model.TwitterAccessToken = object.Equals(model.TwitterAccessToken, null) ? "" : model.TwitterAccessToken;
                userRepo.SaveUser(model);
                return "Successfully Registered";
            }
            else
            {
                return "Something is wrong";
            }
        }

        private bool ValidateRegistrationData(User model)
        {
            bool returnVal = true;
            if (model.FirstName.Trim().Length == 0) { returnVal = false; ViewBag.ErrorFirstName = "Please Enter FirstName"; }
            if (model.LastName.Trim().Length == 0) { returnVal = false; ViewBag.ErrorLastName = "Please Enter LastName"; }
            if (model.Email.Trim().Length == 0) { returnVal = false; ViewBag.ErrorEmail = "Please Enter Email"; }
            bool IsEmailValid = Regex.IsMatch(model.Email.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!IsEmailValid) { returnVal = false; ViewBag.ErrorEmail = "Email Address is Not Valid"; }
            if (model.Password.Trim().Length == 0) { returnVal = false; ViewBag.ErrorPassword = "Please Enter Password"; }
            return returnVal;
        }
    }
}