using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        User SaveUser(User usr);
    }
}