using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string ISO { get; set; }
        public string NiceName { get; set; }
        public string ISO3 { get; set; }
        public int NumCode { get; set; }
        public int PhoneCode { get; set; }
    }
}