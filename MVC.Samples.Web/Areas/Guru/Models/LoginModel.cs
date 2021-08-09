using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Samples.Web.Areas.Guru.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is requierd")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserName{ get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}