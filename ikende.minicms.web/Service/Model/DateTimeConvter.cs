using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ikende.minicms.web.Service.Model
{
    public class DateTimeConvter:Peanut.Mappings.PropertyCastAttribute
    {
        public override object ToColumn(object value, Type ptype, object source)
        {
            DateTime dt = (DateTime)value;
            return dt.Ticks;
        }

        public override object ToProperty(object value, Type ptype, object source)
        {
            long dt = (long)value;
            return new DateTime(dt);
        }
    }
}