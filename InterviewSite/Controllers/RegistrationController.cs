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
    }
}