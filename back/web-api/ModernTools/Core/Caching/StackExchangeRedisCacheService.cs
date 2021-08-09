using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace Core.Caching
{
    class StackExchangeRedisCacheService : IRedisCacheService
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int Count(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll<T>(string key)
        {
            throw new NotImplementedException();
        }

        public bool IsSet(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data, DateTime time)
        {
            throw new NotImplementedException();
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            throw new NotImplementedException();
        }
    }
}
