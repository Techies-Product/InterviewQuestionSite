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
        IQuestionRepository questionRepository;
        public QuestionsController()
        {
            questionRepository = new QuestionRepository();
        }
        // GET: Registration
        public ActionResult Create()
        {
            if (object.Equals(Session["UserId"], null))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Question q)
        {
            if (object.Equals(Session["UserId"], null))
            {
                return RedirectToAction("Index", "Login");
            }
            q.UserId = Session["UserId"].ToString();
            List<string> tagList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(q.Tags);
            q.Tags=string.Join(",", tagList);
            bool res=questionRepository.CreateQuestion(q);
            ViewBag.Message = (res)
                ? "Question Submitted Successfully"
                : "Error while submitting question";
            ModelState.Clear();
            return View(q);
        }
    }
}