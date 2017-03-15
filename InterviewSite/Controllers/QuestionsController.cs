using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Registration
        public ActionResult Create()
        {
            return View();
        }
    }
}