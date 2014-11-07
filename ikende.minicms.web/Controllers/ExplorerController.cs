using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ikende.minicms.web.Controllers
{
    [Filters.LoginFilter]
    public class ExplorerController : Controller
    {
        //
        // GET: /Explorer/

        public ActionResult Index(string type)
        {

            dynamic eo = new ExpandoObject();
            eo.IsEdit = false;
            switch (type)
            {
                case "css":
                    eo.Files = Core.Utils.GetCss();
                    eo.IsEdit = true;
                    eo.Title = "样式";
                    break;
                case "images":
                    eo.Files = Core.Utils.GetImages();
                    eo.Title = "图片";
                    break;
                case "script":
                    eo.Files = Core.Utils.GetScript();
                    eo.IsEdit = true;
                    eo.Title = "脚本";
                    break;
                default:
                    eo.Files = Core.Utils.GetViews();
                    eo.IsEdit = true;
                    eo.Title = "视图";
                    break;
            }
            eo.Type = type;
            return View(eo);
        }
        public ActionResult delfile(string type)
        {
            string[] files = Request.Form.GetValues("files[]");
            Core.Utils.DeleteFiles(files, type);
            return new StringResult(null);
        }
        public ActionResult upload()
        {
            return View();
        }
        public ActionResult uploadfiles(string type)
        {
            string path = Core.Utils.GetTypePath(type);

            for (int i = 0; i < Request.Files.Count; i++)
            {
                Core.Utils.Save(Request.Files.Get(i), path);
            }
            return new StringResult("ok");
        }
        [ValidateInput(false)]
        public ActionResult savefile(string file, string data)
        {
            Core.Utils.SaveFile(file, data);
            return new StringResult(null);
        }

        public ActionResult Editor(string file)
        {
            dynamic eo = new ExpandoObject();
            eo.File = file;
            eo.Content = Core.Utils.GetFileContent(file);

            return View(eo);
        }

    }
}
