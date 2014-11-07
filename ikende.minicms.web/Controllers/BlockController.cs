using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ikende.minicms.web.Service.Model;

namespace ikende.minicms.web.Controllers
{
     [Filters.LoginFilter]
    public class BlockController : ControllerBase
    {
        //
        // GET: /Block/

        public ActionResult index(int? pageindex)
        {
            dynamic eo = new ExpandoObject();
            int size = 30;
            if (pageindex == null)
                pageindex = 0;
            int count = 0;
            eo.Items = BlockService.List(pageindex.Value, size, out count);
            int pagecount = count / size;
            if (count % size > 0)
                pagecount++;
            eo.PageIndex = pageindex.Value;
            eo.Pages = pagecount;
            return View(eo);
        }
       
        public ActionResult delblock(string id)
        {
            BlockService.Delete(id);
            return new StringResult(null);
        }
        public ActionResult editor(string id, string title)
        {
            TextBlock block = BlockService.Get(id);
            if (block == null)
                block = new TextBlock { Title = title };
            return View(block);
        }
        [ValidateInput(false)]
        public ActionResult save(string id, string title, string data)
        {
            TextBlock block = BlockService.Edit(id, title, data);
            return new StringResult(block.ID);
        }
    }
}
