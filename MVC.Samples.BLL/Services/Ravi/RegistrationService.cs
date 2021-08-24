
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Samples.BLL.Interfaces.Ravi;
using MVC.Samples.Data;
using MVC.Samples.Data.Models;

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
            throw new NotImplementedException();
        }

        public bool EmpCodeValidation(string empCode)
        {
            throw new NotImplementedException();
        }

        public bool SaveUser(UserRegistration user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(UserRegistration user)
        {
            throw new NotImplementedException();
        }

        public bool UserNameValidation(string userName)
        {
            throw new NotImplementedException();
        }

        public string ValidateUser(UserRegistration user)
        {
            throw new NotImplementedException();
        }
    }
}
