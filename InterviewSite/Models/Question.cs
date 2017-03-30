using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string QuestionTitle { get; set; }

        [AllowHtml]
        public string QuestionDetail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Remark { get; set; }
        public string Tags { get; set; }
        public string UniqueQuestionName { get; set; }
    }
}