using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewSite.ViewModels
{
    public class RecentQuestion:Question
    {
        public string DateTimeShow { get; set; }
        public string AuthorName { get; set; }
        public string UserUniqueName { get; set; }
        public int Total { get; set; }
    }
}