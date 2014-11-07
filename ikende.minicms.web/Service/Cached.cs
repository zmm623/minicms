using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ikende.minicms.web.Service.Interfaces;

namespace ikende.minicms.web.Service
{
    class Cached : ICached
    {
        public T Get<T>(Func<T> handler)
        {
            return handler();
        }



        public T Get<T>(Func<T> handler, params object[] key)
        {
            return handler();
        }

        public void Remove<T>(params object[] key)
        {

        }

        public void Set(string key, object data)
        {

        }


        public ICached this[params object[] key]
        {
            get
            { return this; }
           

        }
    }
}