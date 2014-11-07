using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ikende.minicms.web.Controllers
{
    public class StringResult : ActionResult
    {
        public StringResult(string value)
        {
            Value = value;
        }
        public string Value
        {
            get;
            set;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.RequestContext.HttpContext.Response;

            response.Clear();
            response.ContentType = "text/html; charset=UTF-8";
            if (Value != null)
            {

                response.Output.Write(Value);
            }
            response.End();
        }
    }
}