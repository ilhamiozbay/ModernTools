using Core.CustomException;
using Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Caching
{
    public class RedisCacheService : IRedisCacheService
    {
        #region Fields
        public readonly IOptions<ModernToolsConfig> _modernToolsConfig;
        private readonly RedisEndpoint _conf = null;
        #endregion

        public RedisCacheService(IOptions<ModernToolsConfig> modernToolsConfig)
        {
            _modernToolsConfig = modernToolsConfig;
            _conf = new RedisEndpoint
            {
                Host = _modernToolsConfig.Value.RedisEndPoint,
                Port = _modernToolsConfig.Value.RedisPort,
                Password = "",
                RetryTimeout = 1000
            };
        }

        public T Get<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    return client.Get<T>(key);
                }
            }
            catch (Exception)
            {

                //throw new RedisNotAvailableException();
                return default;
            }
        }

        public IList<T> GetAll<T>(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    var keys = client.SearchKeys(key);
                    if (keys.Any())
                    {
                        IEnumerable<T> dataList = client.GetAll<T>(keys).Values;
                        return dataList.ToList();
                    }

                    return new List<T>();
                }
            }
            catch (Exception)
            {
                throw new RedisNotAvailableException();
            }
        }
        public void Set(string key, object data)
        {
            Set(key, data, DateTime.Now.AddMinutes(_modernToolsConfig.Value.RedisTimeout));
        }

        public void Set(string key, object data, DateTime time)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    var dataSerialize = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                    {
                        PreserveReferencesHandling =
                        PreserveReferencesHandling.Objects
                    });
                    client.Set(key, Encoding.UTF8.GetBytes(dataSerialize), time);
                }
            }
            catch
            {

                throw new RedisNotAvailableException();
            }
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    client.SetAll(values);
                }
            }
            catch
            {

                throw new RedisNotAvailableException();
            }
        }

        public int Count(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    return client.SearchKeys(key).Where(s => s.Contains(":") &&
                    s.Contains("Mobile-RefreshToken")).ToList().Count;
                }
            }
            catch
            {
                throw new RedisNotAvailableException();
            }
        }

        public void Clear()
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    client.RemoveAll(client.GetAllKeys());
                }
            }
            catch
            {

                throw;
            }
        }




        public bool IsSet(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    return client.ContainsKey(key);
                }
            }
            catch
            {

                throw new RedisNotAvailableException();
            }
        }

        public void Remove(string key)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    client.Remove(key);
                }
            }
            catch
            {
                throw new RedisNotAvailableException();
            }
        }

        public void RemoveByPattern(string pattern)
        {
            try
            {
                using (IRedisClient client = new RedisClient(_conf))
                {
                    var keys = client.SearchKeys(pattern);
                    client.RemoveAll(keys);
                }
            }
            catch
            {

                throw new RedisNotAvailableException();
            }
        }



    }
}
