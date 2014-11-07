using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ikende.minicms.web.Models
{
    public class File:IComparable<File>
    {
        public File(System.IO.FileInfo info)
        {
            Name = info.Name;
            Size = ((double)info.Length / (double)1024).ToString("0.00(KB)");
            Path= info.FullName.Replace(HttpContext.Current.Request.PhysicalApplicationPath,"");
            CreateTime = info.CreationTime;
        }
        public string Path
        {
            get;
            set;
        }

        public string Name { get; set; }

        public string Size { get; set; }

        public DateTime CreateTime { get; set; }

        public int CompareTo(File other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}