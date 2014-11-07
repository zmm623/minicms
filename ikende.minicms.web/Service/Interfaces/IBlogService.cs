using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ikende.minicms.web.Service.Model;

namespace ikende.minicms.web.Service.Interfaces
{
    public interface IBlogService
    {
        IList<Blog> List(string category, int size, int index, out int pages);

        Blog Get(string id);

        Blog Save(string id,string owner, string title, string keywords, string data, params string[] categories);

        IList<BlogCategory> ListCategories(string blog=null);

        IList<string> GetBlogSelectedCategory(string blog);

        ICached Cached { get; set; }

        void Delete(params string[] blogs);

        void CategorySave(string title);

        void CategoryDelete(params string[] categories);

        string SignatureEdit(string user, string data);

        Signature GetSignature(string user);

        IList<Blog> GetRelationBlogs(string blogid);
      
    }
}
