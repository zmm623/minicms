using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ikende.minicms.web.Controllers
{
    public class ControllerBase:Controller
    {
        public ControllerBase()
        {
            UserService = new Service.UserService();
            BlockService = new Service.BlockService();
            BlogService = new Service.BlogService();
        }
        public Service.Interfaces.IUserService UserService
        {
            get;
            private set;
        }
        public Service.Interfaces.IBlockService BlockService
        {
            get;
            private set;
        }
        public Service.Interfaces.IBlogService BlogService
        {
            get;
            private set;
        }
    }
}