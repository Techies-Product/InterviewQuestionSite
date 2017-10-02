using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Controllers
{
    public class AnswersController : Controller
    {
        IAnswerRepository _iAnswerRepository;
        public AnswersController()
        {
            _iAnswerRepository = new AnswerRepository();
        }
        // GET: Answers 
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SubmitAnswer(string answer, string qid)
        {
            if (!object.Equals(Session["UserId"], null))
            {
                Answer _answer = new Answer()
                {
                    AnswerDetail = answer,
                    QuestionId = qid,
                    UserId = Session["UserId"].ToString()
                };
                return Json(_iAnswerRepository.InsertAnswer(_answer), JsonRequestBehavior.AllowGet);
            }
            return Json("Login", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpvoteDownvote(string answerId, bool IsUpvote)
        {
            int returnVal = -1;
            if (!object.Equals(Session["UserId"], null))
            {
                returnVal= _iAnswerRepository.UpvoteDownvote(answerId, IsUpvote, Session["UserId"].ToString());
            }
            return Json(returnVal,JsonRequestBehavior.AllowGet);
        }
    }
}