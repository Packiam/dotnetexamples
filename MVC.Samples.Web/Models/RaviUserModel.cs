using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Samples.Web.Models
{
    public class RaviUserModel
    {
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required(ErrorMessage ="The Age value must be 18 to 100")]
        [Range(18,100)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Marital { get; set; }
        public string City { get; set; }
        public List<string> Interested { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}