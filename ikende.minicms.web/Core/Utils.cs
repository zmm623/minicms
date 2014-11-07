using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
#if MONO
using Mono.Data.Sqlite;
#else
using System.Data.SQLite;
#endif
namespace ikende.minicms.web.Core
{
#if MONO
    public class SqliteDriver : Peanut.DriverTemplate<
   SqliteConnection,
    SqliteCommand,
    SqliteDataAdapter,
    SqliteParameter,
    Peanut.SqlitBuilder>
    {
    }
#else
    public class SqliteDriver : Peanut.DriverTemplate<
      SQLiteConnection,
      SQLiteCommand,
       SQLiteDataAdapter,
       SQLiteParameter,
       Peanut.SqlitBuilder>
    {
    }
#endif
    public class Utils
    {

        public static Service.Model.User Loginer
        {
            get
            {
                System.Collections.IDictionary dict = HttpContext.Current.Items;
                if (dict["_ISLOAD_USER"] == null)
                {
                    HttpCookie loginer = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (loginer != null && loginer.Value != null)
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(loginer.Value);
                        string userid = ticket.Name;
                        Service.Model.User user = new Service.UserService().Get(userid);
                        if (user != null)
                            dict["_LOGINER"] = user;
                    }
                    dict["_ISLOAD_USER"] = true;
                }
                return (Service.Model.User)dict["_LOGINER"];
            }

        }
        public static void SetLogin(string name)
        {
            FormsAuthentication.SetAuthCookie(name, true);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(name, false, 1200);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static void Signout()
        {
            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie myCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(myCookie);
            }
        }
        public static IList<Models.File> GetViews()
        {
            List<Models.File> result = new List<Models.File>();
            string path = HttpContext.Current.Request.PhysicalApplicationPath + string.Format("Views{0}home", System.IO.Path.DirectorySeparatorChar);
            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                result.Add(new Models.File(new System.IO.FileInfo(file)));
            }
            result.Sort();
            return result;
        }
        public static IList<Models.File> GetCss()
        {
            List<Models.File> result = new List<Models.File>();
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "css";
            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                result.Add(new Models.File(new System.IO.FileInfo(file)));
            }
            result.Sort();
            return result;
        }
        public static IList<Models.File> GetScript()
        {
            List<Models.File> result = new List<Models.File>();
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "scripts";
            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                result.Add(new Models.File(new System.IO.FileInfo(file)));
            }
            result.Sort();
            return result;
        }
        public static IList<Models.File> GetImages()
        {
            List<Models.File> result = new List<Models.File>();
            string path = HttpContext.Current.Request.PhysicalApplicationPath + "images";
            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                result.Add(new Models.File(new System.IO.FileInfo(file)));
            }
            result.Sort();
            return result;
        }
        public static string GetFileContent(string file)
        {
            string filename = HttpContext.Current.Request.PhysicalApplicationPath + file;
            if (System.IO.File.Exists(filename))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filename, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            return "";
        }
        public static void Save(HttpPostedFileBase file, string path)
        {
            int size = 1024 * 8;
            string filename = path + file.FileName;
            byte[] buffer = new byte[size];
            using (System.IO.FileStream stream = System.IO.File.Create(filename))
            {
                int count = file.InputStream.Read(buffer, 0, size);
                while (count > 0)
                {
                    stream.Write(buffer, 0, count);
                    count = file.InputStream.Read(buffer, 0, size);
                }
                stream.Flush();
            }
        }
        public static string GetFileName(string name)
        {
            return HttpContext.Current.Server.UrlEncode(name);
        }
        public static void DeleteFiles(string[] files, string type)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            foreach (string file in files)
            {
                string filename = path + file;
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
            }
        }
        public static string GetTypePath(string type)
        {
            string path;
            switch (type)
            {
                case "view":
                    path = HttpContext.Current.Request.PhysicalApplicationPath + string.Format("views{0}home{0}", System.IO.Path.DirectorySeparatorChar);
                    break;
                case "script":
                    path = HttpContext.Current.Request.PhysicalApplicationPath + string.Format("scripts{0}", System.IO.Path.DirectorySeparatorChar);
                    break;
                case "css":
                    path = HttpContext.Current.Request.PhysicalApplicationPath + string.Format("css{0}", System.IO.Path.DirectorySeparatorChar);
                    break;
                case "image":
                    path = HttpContext.Current.Request.PhysicalApplicationPath + string.Format("images{0}", System.IO.Path.DirectorySeparatorChar);
                    break;
                default:
                    path = HttpContext.Current.Request.PhysicalApplicationPath + string.Format("views{0}home{0}", System.IO.Path.DirectorySeparatorChar);
                    break;
            }
            return path;
        }

        public static void SaveFile(string file, string data)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            string filename = path + file;
            if (System.IO.File.Exists(filename))
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filename, false, Encoding.UTF8))
                {
                    writer.Write(data);
                }
            }
        }
    }

    public static class MyExtensions
    {
        public static IHtmlString Block(this WebViewPage page, string title)
        {
            Service.Model.TextBlock tb = (Service.Model.TextBlock.title == title).ListFirst<Service.Model.TextBlock>();
            StringBuilder sb = new StringBuilder();
            if (Utils.Loginer != null)
            {
                sb.AppendLine("<div>");

            }
            if (tb != null)
                sb.Append(tb.Content);

            if (Utils.Loginer != null)
            {
                sb.AppendFormat("<div><a style=\"padding: 2px 20px 2px 2px;    margin-right: 20px;    margin-left: 20px;    text-align: right;\" href=\"/block/editor?id={0}&title={1}\"><b>[编辑]</b></a></div>", tb == null ? "" : tb.ID, HttpContext.Current.Server.UrlEncode(title));
                sb.AppendLine("</div>");
            }
            return page.Html.Raw(sb.ToString());
        }


    }
}