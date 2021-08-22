using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.CustomException;
using Core.Models;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Core.Caching
{
    public class StackExchangeRedisCacheService : IRedisCacheService
    {
        private readonly IOptions<ModernToolsConfig> _modernToolsConfig;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly IDatabase _database;

        public StackExchangeRedisCacheService(IOptions<ModernToolsConfig> modernToolsConfig, IConnectionMultiplexer connectionMultiplexer)
        {
            _modernToolsConfig = modernToolsConfig;
            _connectionMultiplexer = connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
        }

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
            try
            {
                return JsonConvert.DeserializeObject<T>(_database.StringGet(key));
            }
            catch (Exception)
            {
                return default;
            }
        }

        public IList<T> GetAll<T>(string pattern)
        {
            try
            {
                var server = _connectionMultiplexer.GetServer("");
                if (server != null)
                {
                    var keys = server.Keys(pattern: pattern);

                    //if (keys.Any())
                    //{
                    //    return keys.ToList();
                    //}
                }

                return new List<T>();
            }
            catch (Exception)
            {
                throw new RedisNotAvailableException();
            }
        }

        public bool IsSet(string key)
        {
            return _database.KeyExists(key);
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var server = _connectionMultiplexer.GetServer("");

            if (server != null)
            {
                RedisKey[] keys = server.Keys(pattern: pattern).ToArray();
                _database.KeyDelete(keys);
            }
        }

        public void Set(string key, object data)
        {
            Set(key, data, DateTime.Now.AddMinutes(_modernToolsConfig.Value.RedisTimeout));
        }

        public void Set(string key, object data, DateTime expireAt)
        {
            try
            {
                DateTime current = DateTime.Now;

                TimeSpan? expiry = null;
                if (expireAt > current) expiry = TimeSpan.FromSeconds((expireAt - current).TotalSeconds);

                var dataSerialize = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                {
                    PreserveReferencesHandling =
                        PreserveReferencesHandling.Objects
                });
                _database.StringSet(key, Encoding.UTF8.GetBytes(dataSerialize), expiry);

            }
            catch
            {

                throw new RedisNotAvailableException();
            }
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            throw new NotImplementedException();
        }
    }
}
