using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using ikende.minicms.web.Service.Model;
using Peanut;

namespace ikende.minicms.web.Service
{
    public class BlogService : Interfaces.IBlogService
    {
        public BlogService()
        {
            Cached = new Service.Cached();
        }

        public IList<Blog> List(string category, int size, int index, out int pages)
        {

            Expression exp = new Expression();
            if (!string.IsNullOrEmpty(category))
                exp &= Blog.iD == BlogLinkCategory.blog[BlogLinkCategory.category == category];
            int count = exp.Count<Blog>();
            pages = count / size;
            if (count % size > 0)
                pages++;

            IList<Blog> result = exp.List<Blog>(new Region(index, size), Blog.createTime.Desc);
            foreach (Blog item in result)
            {
                item.Categories = ListCategories(item.ID);
            }
            return result;


        }


        public IList<BlogCategory> ListCategories(string blog = null)
        {
            Expression exp = new Expression();
            if (blog != null)
                exp &= BlogCategory.iD == BlogLinkCategory.category[BlogLinkCategory.blog == blog];
            IList<BlogCategory> result = exp.List<BlogCategory>();
            foreach (BlogCategory item in result)
            {
                item.Blogs = (BlogLinkCategory.category == item.ID).Count<BlogLinkCategory>();
            }
            return result;
        }



        public Blog Get(string id)
        {
            Blog result= (Blog.iD == id).ListFirst<Blog>();
            if(result !=null)
                result.Categories = ListCategories(result.ID);
            return result;
        }

        public Blog Save(string id, string owner, string title, string keywords, string data, params string[] categories)
        {
            Blog blog = Get(id);
            using (IConnectinContext cc = DBContext.DB1)
            {
                cc.BeginTransaction();
                if (blog == null)
                {
                    blog = new Blog();
                    blog.Owner = owner;
                }
                blog.Title = title;
                blog.Keywords = keywords;
                blog.Content = data;
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(data);
                blog.Summary = doc.DocumentNode.InnerText;
                blog.Summary = blog.Summary.Substring(0, blog.Summary.Length > 300 ? 300 : blog.Summary.Length);
                blog.Save();
                (BlogLinkCategory.blog == id).Delete<BlogLinkCategory>();
                foreach (string item in categories)
                {
                    BlogLinkCategory blc = new BlogLinkCategory();
                    blc.Blog = blog.ID;
                    blc.Category = item;
                    blc.Save();
                }
                cc.Commit();
            }

            return blog;

        }

        public void Delete(params string[] blogs)
        {
            using (IConnectinContext cc = DBContext.DB1)
            {
                cc.BeginTransaction();
                (BlogLinkCategory.blog == blogs).Delete<BlogLinkCategory>();
                (Blog.iD == blogs).Delete<Blog>();
                cc.Commit();
            }
        }

        public void CategorySave(string title)
        {
            BlogCategory category = new BlogCategory();
            category.Name = title;
            category.Save();
        }

        public void CategoryDelete(params string[] categories)
        {
            using (IConnectinContext cc = DBContext.DB1)
            {
                cc.BeginTransaction();
                (BlogLinkCategory.category == categories).Delete<BlogLinkCategory>();
                (BlogCategory.iD == categories).Delete<BlogCategory>();
                cc.Commit();
            }
        }

        public Interfaces.ICached Cached
        {
            get;
            set;
        }


        public IList<string> GetBlogSelectedCategory(string blog)
        {
            return (BlogLinkCategory.blog == blog).GetValues<string, BlogLinkCategory>(BlogLinkCategory.category);
        }


        public string SignatureEdit(string user, string data)
        {
            Model.Signature singnature = GetSignature(user);
            if (singnature == null)
            {
                singnature = new Model.Signature();
                singnature.User = user;
            }
            singnature.Content = data;
            singnature.Save();
            return data;
        }


        public Signature GetSignature(string user)
        {
            return (Model.Signature.user == user).ListFirst<Model.Signature>();
        }


        public IList<Blog> GetRelationBlogs(string blogid)
        {
            return (Blog.iD == BlogLinkCategory.blog[BlogLinkCategory.category == BlogLinkCategory.category[BlogLinkCategory.blog == blogid]]
                & Blog.iD != blogid).List<Blog>(Blog.createTime.Desc);
        }
    }
}
