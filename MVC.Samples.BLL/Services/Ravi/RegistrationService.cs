
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Samples.BLL.Interfaces.Ravi;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;
using MVC.Samples.Data.Models.Ravi;

namespace MVC.Samples.BLL.Services.Ravi
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
            string message = null;
            string sucess ="ok";
            if (user.Password == null || user.Password.Length<4) { return message; }
            return sucess;
        }

        public bool EmpCodeValidation(string empCode)
        {

            if (myDatabase.userRegistrations.Any(x => x.EmpCode == empCode))
            {
                return false;
            }
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

        public bool UserNameValidation(string userName)
        {
           
            if (myDatabase.userRegistrations.Any(x => x.Name == userName))
            {
                return false;
            }
            return true;
        }

        public string ValidateUser(UserRegistration user)
        {
            string message = null;
            string success = "Your are eligble";
            if(user.Age<18 || user.Age >= 100) { return message; }
            return success;
        }
    }
}
