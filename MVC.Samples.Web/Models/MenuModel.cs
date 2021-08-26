using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Samples.Web.Models
{
    public class MenuModel
    {
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string  Action { get; set; }
    }
}