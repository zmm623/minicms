using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ikende.minicms.web.Service.Model;

namespace ikende.minicms.web.Service.Interfaces
{
    public interface IUserService
    {
        Model.User Get(string name);

        Model.User CreateUser(string name, string pwd);

        Model.User Login(string name, string password);

        User ChangePWD(string name, string oldpassword, string password);

        ICached Cached { get; set; }
    }
}
