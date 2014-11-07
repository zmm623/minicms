using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ikende.minicms.web.Service.Interfaces
{
    public interface ICached
    {
        T Get<T>(Func<T> handler);
        T Get<T>(Func<T> handler, params object[] key);
        void Remove<T>(params object[] key);
        void Set(string key, object data);
        ICached this[params object[] key] { get; }
    }
  
}
