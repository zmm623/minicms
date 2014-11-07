using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ikende.minicms.web.Controllers
{
    public class HomeController : ControllerBase
    {
        //
        // GET: /Home/

        public ActionResult Index(string page)
        {
            if(string.IsNullOrEmpty(page))
                return View();
        
            return View("~/Views/home/" + page + ".cshtml");
        }
        public ActionResult BlogItem(string id)
        {
            dynamic eo = new ExpandoObject();
            eo.Categories = BlogService.ListCategories();
            eo.Blog = BlogService.Get(id);
            eo.Relation = BlogService.GetRelationBlogs(id);
            return View(eo);
        }
        public ActionResult Blog(int? pageindex, string category)
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
