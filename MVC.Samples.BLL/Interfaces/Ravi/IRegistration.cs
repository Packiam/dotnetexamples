using MVC.Samples.Data.Models;
using MVC.Samples.Data.Models.Ravi;
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
        string ValidateUser(UserLogin user, out UserRegistration userModel);
    }
}
