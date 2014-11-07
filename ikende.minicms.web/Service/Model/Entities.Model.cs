using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Peanut.Mappings;

namespace ikende.minicms.web.Service.Model
{
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class User : Peanut.Mappings.DataObject
    {
        private string mName;
        public static Peanut.FieldInfo<string> name = new Peanut.FieldInfo<string>("User", "Name");
        private string mPassword;
        public static Peanut.FieldInfo<string> password = new Peanut.FieldInfo<string>("User", "Password");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        public virtual string Name
        {
            get
            {
                return mName;
                
            }
            set
            {
                mName = value;
                EntityState.FieldChange("Name");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        [StringCrypto]
        public virtual string Password
        {
            get
            {
                return mPassword;
                
            }
            set
            {
                mPassword = value;
                EntityState.FieldChange("Password");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class TextBlockCategory : Peanut.Mappings.DataObject
    {
        private string mID;
        public static Peanut.FieldInfo<string> iD = new Peanut.FieldInfo<string>("TextBlockCategory", "ID");
        private string mName;
        public static Peanut.FieldInfo<string> name = new Peanut.FieldInfo<string>("TextBlockCategory", "Name");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        [UID]
        public virtual string ID
        {
            get
            {
                return mID;
                
            }
            set
            {
                mID = value;
                EntityState.FieldChange("ID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Name
        {
            get
            {
                return mName;
                
            }
            set
            {
                mName = value;
                EntityState.FieldChange("Name");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class TextBlock : Peanut.Mappings.DataObject
    {
        private string mID;
        public static Peanut.FieldInfo<string> iD = new Peanut.FieldInfo<string>("TextBlock", "ID");
        private string mTitle;
        public static Peanut.FieldInfo<string> title = new Peanut.FieldInfo<string>("TextBlock", "Title");
        private string mCategory;
        public static Peanut.FieldInfo<string> category = new Peanut.FieldInfo<string>("TextBlock", "Category");
        private string mContent;
        public static Peanut.FieldInfo<string> content = new Peanut.FieldInfo<string>("TextBlock", "Content");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        [UID]
        public virtual string ID
        {
            get
            {
                return mID;
                
            }
            set
            {
                mID = value;
                EntityState.FieldChange("ID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Title
        {
            get
            {
                return mTitle;
                
            }
            set
            {
                mTitle = value;
                EntityState.FieldChange("Title");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Category
        {
            get
            {
                return mCategory;
                
            }
            set
            {
                mCategory = value;
                EntityState.FieldChange("Category");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Content
        {
            get
            {
                return mContent;
                
            }
            set
            {
                mContent = value;
                EntityState.FieldChange("Content");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Blog : Peanut.Mappings.DataObject
    {
        private string mID;
        public static Peanut.FieldInfo<string> iD = new Peanut.FieldInfo<string>("Blog", "ID");
        private string mTitle;
        public static Peanut.FieldInfo<string> title = new Peanut.FieldInfo<string>("Blog", "Title");
        private string mContent;
        public static Peanut.FieldInfo<string> content = new Peanut.FieldInfo<string>("Blog", "Content");
        private string mKeywords;
        public static Peanut.FieldInfo<string> keywords = new Peanut.FieldInfo<string>("Blog", "blogkeyword");
        private DateTime mCreateTime;
        public static Peanut.FieldInfo<DateTime> createTime = new Peanut.FieldInfo<DateTime>("Blog", "CreateTime");
        private string mSummary;
        public static Peanut.FieldInfo<string> summary = new Peanut.FieldInfo<string>("Blog", "Summary");
        private string mOwner;
        public static Peanut.FieldInfo<string> owner = new Peanut.FieldInfo<string>("Blog", "Owner");
        ///<summary>
        ///Type:string
        ///</summary>
        [UID]
        [ID()]
        public virtual string ID
        {
            get
            {
                return mID;
                
            }
            set
            {
                mID = value;
                EntityState.FieldChange("ID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Title
        {
            get
            {
                return mTitle;
                
            }
            set
            {
                mTitle = value;
                EntityState.FieldChange("Title");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Content
        {
            get
            {
                return mContent;
                
            }
            set
            {
                mContent = value;
                EntityState.FieldChange("Content");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column("blogkeyword")]
        public virtual string Keywords
        {
            get
            {
                return mKeywords;
                
            }
            set
            {
                mKeywords = value;
                EntityState.FieldChange("Keywords");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        [DateTimeConvter]
        [NowDate]
        public virtual DateTime CreateTime
        {
            get
            {
                return mCreateTime;
                
            }
            set
            {
                mCreateTime = value;
                EntityState.FieldChange("CreateTime");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Summary
        {
            get
            {
                return mSummary;
                
            }
            set
            {
                mSummary = value;
                EntityState.FieldChange("Summary");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Owner
        {
            get
            {
                return mOwner;
                
            }
            set
            {
                mOwner = value;
                EntityState.FieldChange("Owner");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Signature : Peanut.Mappings.DataObject
    {
        private string mUser;
        public static Peanut.FieldInfo<string> user = new Peanut.FieldInfo<string>("Signature", "User");
        private string mContent;
        public static Peanut.FieldInfo<string> content = new Peanut.FieldInfo<string>("Signature", "Content");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        public virtual string User
        {
            get
            {
                return mUser;
                
            }
            set
            {
                mUser = value;
                EntityState.FieldChange("User");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Content
        {
            get
            {
                return mContent;
                
            }
            set
            {
                mContent = value;
                EntityState.FieldChange("Content");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class BlogCategory : Peanut.Mappings.DataObject
    {
        private string mID;
        public static Peanut.FieldInfo<string> iD = new Peanut.FieldInfo<string>("BlogCategory", "ID");
        private string mName;
        public static Peanut.FieldInfo<string> name = new Peanut.FieldInfo<string>("BlogCategory", "Name");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        [UID]
        public virtual string ID
        {
            get
            {
                return mID;
                
            }
            set
            {
                mID = value;
                EntityState.FieldChange("ID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Name
        {
            get
            {
                return mName;
                
            }
            set
            {
                mName = value;
                EntityState.FieldChange("Name");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ FanJianHan 2010-2013
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class BlogLinkCategory : Peanut.Mappings.DataObject
    {
        private string mBlog;
        public static Peanut.FieldInfo<string> blog = new Peanut.FieldInfo<string>("BlogLinkCategory", "Blog");
        private string mCategory;
        public static Peanut.FieldInfo<string> category = new Peanut.FieldInfo<string>("BlogLinkCategory", "Category");
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Blog
        {
            get
            {
                return mBlog;
                
            }
            set
            {
                mBlog = value;
                EntityState.FieldChange("Blog");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Category
        {
            get
            {
                return mCategory;
                
            }
            set
            {
                mCategory = value;
                EntityState.FieldChange("Category");
                
            }
            
        }
        
    }
    
}
