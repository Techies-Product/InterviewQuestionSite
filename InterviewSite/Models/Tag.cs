using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Display(Name ="Tag Name")]
        public string Name { get; set; }
        public int? CompanyOrCategoryId { get; set; }
        [Display(Name = "Is Company")]
        public bool IsCompany { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }
    }
}