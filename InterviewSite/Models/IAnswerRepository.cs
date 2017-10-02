using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSite.Models
{
    public interface IAnswerRepository
    {
        bool InsertAnswer(Answer a);
        int UpvoteDownvote(string answerId, bool IsUpvote,string UserId);
    }
}
