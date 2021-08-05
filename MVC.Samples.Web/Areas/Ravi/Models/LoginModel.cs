﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Samples.Web.Areas.Ravi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email is requierd")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}