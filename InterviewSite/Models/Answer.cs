using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class Answer
    {
        public string AnswerId { get; set; }
        public string AnswerDetail { get; set; }
        public string QuestionId { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string UserId { get; set; }
    }
}