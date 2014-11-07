using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Peanut.Mappings;
namespace ikende.minicms.web.Service.Model
{
    [Table]
    public interface IUser
    {
        [ID]
         string Name { get; set; }
        [Column]
        [StringCrypto]
         string Password { get; set; }
    }
    [Table]
    public interface ITextBlockCategory
    {
        [ID]
        [UID]
        string ID { get; set; }
        [Column]
        string Name { get; set; }
    }
    [Table]
    public interface ITextBlock
    {
        [ID]
        [UID]
        string ID { get; set; }
        [Column]
        string Title { get; set; }
        [Column]
        string Category { get; set; }
        [Column]
        string Content { get; set; }
    }
    [Table]
    public interface IBlog
    {
        [UID]
        [ID]
        string ID { get; set; }
        [Column]
        string Title { get; set; }
        [Column]
        string Content { get; set; }
        [Column("blogkeyword")]
        string Keywords { get; set; }
        [Column]
        [DateTimeConvter]
        [NowDate]
        DateTime CreateTime { get; set; }
        [Column]
        string Summary { get; set; }
        [Column]
        string Owner { get; set; }
    }
    [Table]
    public interface ISignature
    {
        [ID]
        string User { get; set; }
        [Column]
        string Content { get; set; }
    }
    [Table]
    public interface IBlogCategory
    {
        [ID]
        [UID]
        string ID { get; set; }
        [Column]
        string Name { get; set; }
    }
    [Table]
    public interface IBlogLinkCategory
    {
        [Column]
        string Blog { get; set; }
        [Column]
        string Category { get; set; }
    }
    public partial class BlogCategory
    {
        public int Blogs { get; set; }
    }

    public partial class Blog
    {
        public IList<BlogCategory> Categories
        {
            get;
            set;
        }
    }
}