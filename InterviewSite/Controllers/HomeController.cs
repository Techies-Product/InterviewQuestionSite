using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IQuestionRepository questionRepository = new QuestionRepository();
            return View(questionRepository.GetRecentQuestions());
        }
    }
}