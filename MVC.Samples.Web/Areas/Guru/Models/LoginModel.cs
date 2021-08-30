using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Samples.Web.Areas.Guru.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName requierd")]
       
        public string Name{ get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Required]
        public string EmployeeCode { get; set; }
    }
}