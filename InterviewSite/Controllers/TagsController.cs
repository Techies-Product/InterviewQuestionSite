using InterviewSite.CustomActionFilters;
using InterviewSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterviewSite.Controllers
{
    [IsAdmin]
    public class TagsController : Controller
    {
        ITagRepository iTagRepository;
        public TagsController()
        {
            iTagRepository = new TagRepository();
        }
        /// <summary>
        /// This action is used to get list of tags with Page Number 
        /// </summary>
        /// <param name="id">Here Id Parameter is working as a Page Number</param>
        /// <returns></returns>
        public ActionResult Index(int id=1)
        {
            var tagList=iTagRepository.GetTags(PageNumber: id, PageSize:Convert.ToInt32(ConfigurationManager.AppSettings["TagListPageSize"]));
            ViewBag.SelectedPage = id;
            return View(tagList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Name, bool hddIsCompany)
        {
            if (string.IsNullOrEmpty(Name))
            {
                ViewBag.ErrorTagName = "Please enter tag name";
                return View();
            }
            iTagRepository.Save(0, Name,0, hddIsCompany);
            return View();
        }
    }
}