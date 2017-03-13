using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class User
    {
        public string UserId { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [ForeignKey("Countries")]
        public int Country { get; set; }
        public int TotalPoints { get; set; }
        public string RegistrationIpAddress { get; set; }
        public string UserType { get; set; }
        public DateTime RegistraitonDate { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public string FacebookProfile { get; set; }
        public string FacebookAccessToken { get; set; }
        public string TwitterHandle { get; set; }
        public string TwitterAccessToken { get; set; }
        public string GoogleProfile { get; set; }
        public string GoogleAccessToken { get; set; }
        public bool IsBlocked { get; set; }
        public string User_Unique_Name { get; set; }
        public virtual Country Countries{ get; set; }
    }
}