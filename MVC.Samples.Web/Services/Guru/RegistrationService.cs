using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Samples.BLL.Interfaces.Guru;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using MVC.Samples.Data.Models.Guru;

namespace MVC.Samples.BLL.Services.Guru
{
    public class RegistrationService : IRegistration
    {
        public readonly MyDatabase myDatabase;
        public RegistrationService()
        {
            myDatabase = new MyDatabase();
        }

        public string BasicValidations(UserRegistration user)
        {
            if (string.IsNullOrEmpty(user.Name)) { return "Name is mandatory"; }
            else if (string.IsNullOrEmpty(user.Password)) { return "Password is mandatory"; }
            else if (string.IsNullOrEmpty(user.EmpCode)) { return "Code is mandatory"; }
            else if (string.IsNullOrEmpty(user.UserName)) { return "Username is mandatory"; }
            else if (string.IsNullOrEmpty(user.Role)) { return "Role is mandatory"; }
            //else if (user.Password == user.ConfirmPassword) { return "Password and Confirm Password should be equal."; }
            else if (user.Age < 18 || user.Age > 60) { return "Invalid age."; }
            else if (!EmpCodeValidation(user.EmpCode)) { return "Employee Code duplication."; }
            else if (!UserNameValidation(user.Name)) { return "Username duplication."; }
            return "";
        }
        public bool EmpCodeValidation(string empCode)
        {
            if (myDatabase.userRegistrations.Any(x => x.EmpCode == empCode)) { return false; }
            return true;
        }
        public bool UserNameValidation(string userName)
        {
            if (myDatabase.userRegistrations.Any(x => x.Name == userName)){ return false; }
            return true;
        }

        public bool SaveUser(UserRegistration user)
        {
            myDatabase.userRegistrations.Add(user);
            myDatabase.SaveChanges();
            return true;
        }

        public bool UpdateUser(UserRegistration user)
        {

            var data = myDatabase.userRegistrations.Find(user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.Address = user.Address;
                data.UserName = user.UserName;
                data.Age = user.Age;
                data.EmpCode = user.EmpCode;
            }
            myDatabase.SaveChanges();
            return true;
        }

        

        public string ValidateUser(UserLogin user, out UserRegistration userModel)
        {
            /*
             * 1. UserName is wrong. -> "Invalid Username."
             * 2. UserName correct but Password is wrong. -> "Invalid Password."
             * 3. Based on roles -> send menus.
            */
            string name = user.Name;
            string pass = user.Password;
            //string success = "ok";
            //string message = "Unauthorized Role";
            //string fail = "fail";
            //string admin = "Admin";
            userModel = null;
            UserRegistration userModel1 = myDatabase.userRegistrations.Where(x => x.UserName == name).FirstOrDefault();
            if (name == null) { return "Username is Required."; }
            if (pass == null) { return "Password is Required."; }
            else if (userModel1.Password != user.Password) { return "Password is wrong."; }
            userModel = userModel1;
            return "";

            //if (myDatabase.userRegistrations.Any(x => x.UserName == name) && myDatabase.userRegistrations.Any(x => x.Password == pass))
            //{
            //    if(myDatabase.userRegistrations.Any(x => x.Role == admin))
            //    {
            //        return success;
            //    }
            //    return message;
            //}
            //return fail;
        }
    }
}
