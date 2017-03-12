using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewSite.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
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
    }
}