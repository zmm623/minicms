using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ikende.minicms.web.Service.Interfaces
{
    public interface IBlockService
    {
        IList<Model.TextBlock> List( int pageindex,int pagesize, out int count);
        void Delete(string id);
        Model.TextBlock Get(string id);
        Model.TextBlock GetByTitle(string title);
        Model.TextBlock Edit(string id, string title, string data);
        ICached Cached { get; set; }
    }
}
