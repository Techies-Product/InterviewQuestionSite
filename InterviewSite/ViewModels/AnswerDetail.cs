using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewSite.ViewModels
{
    public class AnswerDetail:Answer
    {
        public string FullName { get; set; }
        public string Photo { get; set; }
        public string User_Unique_Name { get; set; }
    }
}