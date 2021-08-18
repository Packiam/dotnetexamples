using MVC.Samples.Web.Areas.Ravi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Samples.Web.Areas.Ravi.Helper
{
    public class SessionHandler
    {
        public static void AddUserSession(RaviUserModel model)
        {
            List<RaviUserModel> models;
            try
            {
                if(HttpContext.Current.Session["USER_DATA"] == null) { models = new List<RaviUserModel>(); }
                else { models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"]; }
                models.Add(model);
                HttpContext.Current.Session["USER_DATA"] = models;
            }
            finally
            {
                models = null;
            }
        }

        public static RaviUserModel ReadUserSession(string userId)
        {
            List<RaviUserModel> models;
            try {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.Name == userId);
            } 
            finally 
            { 
                models = null; 
            }
        }
    }

    public interface ILoginSession
    {
        RaviUserModel ReadUserSession(string userId);
    }
    public class CommonUserSession
    {
        public void AddUserSession(RaviUserModel model)
        {
            List<RaviUserModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { models = new List<RaviUserModel>(); }
                else { models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"]; }
                models.Add(model);
                HttpContext.Current.Session["USER_DATA"] = models;
            }
            finally
            {
                models = null;
            }
        }
    }
    public class UserLoginProcess : CommonUserSession, ILoginSession
    {
        public RaviUserModel ReadUserSession(string userId)
        {
            List<RaviUserModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.Name == userId);
            }
            finally
            {
                models = null;
            }
        }
    }
    public class EmployeeLoginProcess : CommonUserSession, ILoginSession
    {
        public RaviUserModel ReadUserSession(string userId)
        {
            List<RaviUserModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.EmployeeCode == userId);
            }
            finally
            {
                models = null;
            }
        }
    }



    public abstract class ALoginProcess
    {
        public virtual void AddUserSession(RaviUserModel model)
        {
            List<RaviUserModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { models = new List<RaviUserModel>(); }
                else { models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"]; }
                models.Add(model);
                HttpContext.Current.Session["USER_DATA"] = models;
            }
            finally
            {
                models = null;
            }
        }

        public abstract RaviUserModel ReadUserSession(string userId);
    }
    public class UserLoginAbstractProcess : ALoginProcess
    {
        public override RaviUserModel ReadUserSession(string userId)
        {
            List<RaviUserModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.Name == userId);
            }
            finally
            {
                models = null;
            }
        }

        public override void AddUserSession(RaviUserModel model)
        {

            base.AddUserSession(model);
        }
    }
    public class EmpLoginAbstractProcess : ALoginProcess
    {
        public override RaviUserModel ReadUserSession(string code)
        {
            List<RaviUserModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<RaviUserModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.EmployeeCode == code);
            }
            finally
            {
                models = null;
            }
        }
    }
}