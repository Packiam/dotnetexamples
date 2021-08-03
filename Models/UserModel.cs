using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCApplication.Models
{
    public class UserModel
    {

        [Required]
        public string Code { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
        public string Email { get; set; }
        public string Marital { get; set; }
        public string City { get; set; }
        public List<string> Interested { get; set; }
        public List<SelectListItem> CityList { get; set; }
    }
}