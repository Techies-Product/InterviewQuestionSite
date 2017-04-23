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
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
    }
}