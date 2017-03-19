using InterviewSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public interface ITagRepository
    {
        bool Save(int id, string Name, int CompanyOrCategoryId, bool IsCompany);
        IEnumerable<TagList> GetTags(int PageNumber,int PageSize);
    }
}