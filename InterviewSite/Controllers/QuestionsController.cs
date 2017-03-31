using InterviewSite.Models;
using InterviewSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public ActionResult Recent(string Id="1")
        {
            try
            {
                ViewBag.SelectedPage = Convert.ToInt32(Id);
                questionRepository = new QuestionRepository();
                return View(questionRepository.GetRecentQuestions(PageNumber: Convert.ToInt32(Id), PageSize: Convert.ToInt32(ConfigurationManager.AppSettings["RecentQuestionListPageSize"])));
            }
            catch(Exception ex)
            {
                return RedirectToAction("Recent", "Questions");
            }
        }
        public ActionResult Detail(string Id)
        {
            QuestionDetail questionDetail = questionRepository.GetQuestionByUniqueName(Id);
            return View(questionDetail);
        }
    }
}