using MVC.Samples.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Samples.BLL.Interfaces.Ravi
{
    public interface IRegistration
    {
        bool SaveUser(UserRegistration user);
        bool UpdateUser(UserRegistration user);
        string BasicValidations(UserRegistration user);
        bool EmpCodeValidation(string empCode);
        bool UserNameValidation(string userName);
        string ValidateUser(UserRegistration user);
    }
}
