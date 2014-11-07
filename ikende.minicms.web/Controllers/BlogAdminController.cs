using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ikende.minicms.web.Service.Model;
using Peanut;
namespace ikende.minicms.web.Controllers
{
     [Filters.LoginFilter]
    public class BlogAdminController : ControllerBase
    {
        //
        // GET: /BlogAdmin/

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

        public ActionResult Delete(string blog)
        {
            BlogService.Delete(blog);
            return new StringResult(null);
        }

        public ActionResult editor(string id)
        {
            dynamic eo = new ExpandoObject();
            Service.Model.Blog blog = BlogService.Get(id);
            if (blog == null)
                blog = new Service.Model.Blog();
            eo.Blog = blog;
            eo.SelectedCategories = BlogService.GetBlogSelectedCategory(id);
            eo.Categories = BlogService.ListCategories();
            return View(eo);
        
        }
         
        [ValidateInput(false)]
        public ActionResult signature(string data)
        {
            if (Request.HttpMethod == "POST")
            {
                BlogService.SignatureEdit(Core.Utils.Loginer.Name, data);
            }
            else
            {
                Service.Model.Signature signature = BlogService.GetSignature(Core.Utils.Loginer.Name);
                if (signature != null)
                    data = signature.Content;
            }
            return View((object)data);
        }
        public ActionResult category()
        {
            return View(new Expression().List<BlogCategory>());
        }
        [ValidateInput(false)]
        public ActionResult savepost(string id, string title, string data, string keywords, string categories)
        {
            string[] cates = categories.Split(',');
            ikende.minicms.web.Service.Model.Blog blog = BlogService.Save(id,Core.Utils.Loginer.Name, title, keywords, data, cates);
            return new StringResult(blog.ID);
        }

        public ActionResult addcategory(string title)
        {
            BlogService.CategorySave(title);
            return new StringResult(null);
        }
        public ActionResult delcategory(string id)
        {
            BlogService.CategoryDelete(id);
            return new StringResult(null);
        }

    }
}
