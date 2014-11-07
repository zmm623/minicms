using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ikende.minicms.web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Peanut.DBContext.SetConnectionDriver<Core.SqliteDriver>(Peanut.DB.DB1);
            Peanut.DBContext.SetConnectionString(Peanut.DB.DB1, "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"app_data/cmsdb.db;Pooling=true;FailIfMissing=false;");
            AreaRegistration.RegisterAllAreas();
           // new Service.UserService().CreateUser("admin", "admin");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}