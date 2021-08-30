using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Samples.Data.Models.Ravi
{
    public class UserLogin
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string Password { get; set; }
        public string EmployeeCode { get; set; }
    }
}
