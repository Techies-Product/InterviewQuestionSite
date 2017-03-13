using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            model.UserId = CommonFunctions.GetUserId();
            model.RegistrationIpAddress = Request.UserHostAddress;

            model.Password = Convert.ToBase64String(CommonFunctions.Encryption(model.Password,model.UserId));

            model.FacebookAccessToken = object.Equals(model.FacebookAccessToken, null) ? "" : model.FacebookAccessToken;
            model.FacebookProfile = object.Equals(model.FacebookProfile, null) ? "" : model.FacebookProfile;
            model.GoogleAccessToken = object.Equals(model.GoogleAccessToken, null) ? "" : model.GoogleAccessToken;
            model.GoogleProfile = object.Equals(model.GoogleProfile, null) ? "" : model.GoogleProfile;
            model.TwitterHandle = object.Equals(model.TwitterHandle, null) ? "" : model.TwitterHandle;
            model.TwitterAccessToken = object.Equals(model.TwitterAccessToken, null) ? "" : model.TwitterAccessToken;
            UserRepository userRepo = new UserRepository();
            userRepo.SaveUser(model);
            return "Successfully Registered";
        }
    }
}