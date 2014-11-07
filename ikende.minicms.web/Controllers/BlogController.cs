using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ikende.minicms.web.Controllers
{
    public class BlogController : ControllerBase
    {
        //
        // GET: /Blog/

        public ActionResult Index(int? pageindex, string category)
        {
            dynamic eo = new ExpandoObject();
            int size = 30;
            if (pageindex == null)
                pageindex = 0;
            eo.PageIndex = pageindex.Value;
            eo.Category = category;
            int pages;
            eo.Blogs = BlogService.List(category, size, pageindex.Value, out pages);
            eo.Pages = pages;
            eo.Categories = BlogService.ListCategories();

            return View(eo);
        }

    }
}
