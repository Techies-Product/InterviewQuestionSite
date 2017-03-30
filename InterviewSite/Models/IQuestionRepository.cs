using InterviewSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSite.Models
{
    public interface IQuestionRepository
    {
        bool CreateQuestion(Question q);
        List<RecentQuestion> GetRecentQuestions(int PageNumber=1, int PageSize=30);
        QuestionDetail GetQuestionByUniqueName(string QuestionUniqueName);
    }
}
