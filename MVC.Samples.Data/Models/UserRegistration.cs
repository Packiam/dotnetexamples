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
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
