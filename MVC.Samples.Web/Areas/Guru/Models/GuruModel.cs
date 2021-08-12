using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace MVC.Samples.Web.Areas.Guru.Models
{
    [Serializable]
    public class GuruModel
    {
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is requierd")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Conform Password is requierd")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConformPassword { get; set; }

        [Required(ErrorMessage = "The Age value must be 18 to 100")]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Marital { get; set; }
        public string City { get; set; }
        public string Intrested { get; set; }
        public List<SelectListItem> InterestedList { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}