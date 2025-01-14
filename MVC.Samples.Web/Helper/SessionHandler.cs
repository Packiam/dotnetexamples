﻿using System.Web;
using System.Collections.Generic;
using MVC.Samples.Web.Areas.Guru.Models;
using MVC.Samples.Web.Models;

namespace MVC.Samples.Web.Helper
{
    public static class UserSessionHandler
    {
        public static void AddUserSession(LoginModel model)
        {
            List<LoginModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { models = new List<LoginModel>(); }
                else { models = (List<LoginModel>)HttpContext.Current.Session["USER_DATA"]; }
                models.Add(model);
                HttpContext.Current.Session["USER_DATA"] = models;
            }
            finally
            {
                models = null;
            }
        }
        public static void AddRoleSession(MenuModel model)
        {
            List<MenuModel> models;
            try
            {
                if (HttpContext.Current.Session["MenuDetails"] == null) { models = new List<MenuModel>(); }
                else { models = (List<MenuModel>)HttpContext.Current.Session["MenuDetails"]; }
                models.Add(model);
                HttpContext.Current.Session["MenuDetails"] = models;
            }
            finally
            {
                models = null;
            }
        }

        public static GuruModel ReadUserSession(string userId)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.Name == userId);
            }
            finally
            {
                models = null;
            }
        }
        public static GuruModel ReadUserSession(string employeeId, string password)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.EmployeeCode == employeeId);
            }
            finally
            {
                models = null;
            }
        }
        public static void ClearUserSession()
        {
            HttpContext.Current.Session["USER_DATA"] = new List<LoginModel>();
        }

    }

    public interface ILoginSession
    {
        GuruModel ReadUserSession(string userId);
    }
    public class CommonUserSession
    {
        public void AddUserSession(GuruModel model)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { models = new List<GuruModel>(); }
                else { models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"]; }
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
        public GuruModel ReadUserSession(string userId)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"];
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
        public GuruModel ReadUserSession(string userId)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"];
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
        public virtual void AddUserSession(GuruModel model)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { models = new List<GuruModel>(); }
                else { models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"]; }
                models.Add(model);
                HttpContext.Current.Session["USER_DATA"] = models;
            }
            finally
            {
                models = null;
            }
        }

        public abstract GuruModel ReadUserSession(string userId);
    }
    public class UserLoginAbstractProcess : ALoginProcess
    {
        public override GuruModel ReadUserSession(string userId)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.Name == userId);
            }
            finally
            {
                models = null;
            }
        }

        public override void AddUserSession(GuruModel model)
        {

            base.AddUserSession(model);
        }
    }
    public class EmpLoginAbstractProcess : ALoginProcess
    {
        public override GuruModel ReadUserSession(string code)
        {
            List<GuruModel> models;
            try
            {
                if (HttpContext.Current.Session["USER_DATA"] == null) { return null; }
                models = (List<GuruModel>)HttpContext.Current.Session["USER_DATA"];
                return models.Find(exp => exp.EmployeeCode == code);
            }
            finally
            {
                models = null;
            }
        }
    }

}