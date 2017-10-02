using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Index(string id)
        {

            return View();
        }
    }
}