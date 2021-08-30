using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Samples.Data.Models
{
    [Table("Mst_User_Registration")]
    public class UserRegistration
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "EmployeeCode is requierd")]
        public string EmpCode { get; set; }
        [Required]
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is requierd")]
        public string Password { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
