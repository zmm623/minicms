using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ikende.minicms.web.Service.Model;
using Peanut;
namespace ikende.minicms.web.Service
{
    public class UserService : Interfaces.IUserService
    {
        public UserService()
        {
            Cached = new Cached();
        }

        public User Get(string name)
        {

            return (User.name == name).ListFirst<User>();

        }

        public User CreateUser(string name, string pwd)
        {
            User user = new User();
            user.Name = name;
            user.Password = pwd;
            user.Save();
            return user;
        }

        public User ChangePWD(string name, string oldpassword, string password)
        {
            User user = Get(name);
            if (user.Password != oldpassword)
                return null;
            user.Password = password;
            user.Save();
            return user;

        }

        public User Login(string name, string password)
        {
            User user = Get(name);
            if (user != null && user.Password == password)
                return user;
            return null;
        }


        public Interfaces.ICached Cached
        {
            get;
            set;
        }
    }
}