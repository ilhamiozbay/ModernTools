using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Caching
{
   public interface IRedisCacheService
    {
        T Get<T>(string key);
        IList<T> GetAll<T>(string key);
        void Set(string key, object data);
        void Set(string key, object data, DateTime expireAt);
        void SetAll<T>(IDictionary<string,T> values);
        bool IsSet(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
        int Count(string key);
    }
}
