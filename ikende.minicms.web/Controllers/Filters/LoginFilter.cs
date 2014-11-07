using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ikende.minicms.web.Controllers.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class LoginFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Core.Utils.Loginer != null)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                if (filterContext.ActionDescriptor.ActionName == "login")
                    base.OnActionExecuting(filterContext);
                else
                    filterContext.Result = new RedirectResult("/admin/login");
            }
        }
    }
}