using MVC.Samples.Web.Areas.Ravi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Samples.Web.Areas.Ravi.Helper
{
    public class SessionHandler
    {
        public static void AddUserSession(RaviUserModel raviUser)
        {
            List<RaviUserModel> models;
            try
            {
                if(HttpContext.Current.Session["USER_DATA"] == null) { models = new List<RaviUserModel>(); }
                else { models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"]; }
                models.Add(raviUser);
            }
            finally
            {
                models = null;
            }
        }

        public static RaviUserModel ReadUserSession(string name)
        {
            List<RaviUserModel> models;
            try {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.Name == name);
            } 
            finally 
            { 
                models = null; 
            }
        }
    }
}