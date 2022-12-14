using System;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SC.App.Services.Area.Common.Constants;
using StackExchange.Redis;

namespace SC.App.Services.Area.Common.Managers.Cache
{
    public class DistributedCacheManager : IDistributedCacheManager
    {
        /// <summary>
        /// The cache
        /// </summary>
        private readonly IDistributedCache _cache;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor of DistributedCacheManager
        /// </summary>
        /// <param name="cache">The cache</param>
        /// <param name="configuration">The configuration</param>
        public DistributedCacheManager(
            IDistributedCache cache,
            IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public string Get(string key)
        {
            var raw = _cache.Get(key);

            return raw == null ? null : Encoding.UTF8.GetString(raw);
        }

        /// <inheritdoc />
        public T Get<T>(string key)
            where T : new()
        {
            var raw = _cache.Get(key);
            if (raw == null)
            {
                return default(T);
            }

            var decoded = Encoding.UTF8.GetString(raw);

            return JsonConvert.DeserializeObject<T>(decoded);
        }

        /// <inheritdoc />
        public void Set(string key, string value)
        {
            byte[] encoded = Encoding.UTF8.GetBytes(value);
            _cache.Set(key, encoded);
        }

        /// <inheritdoc />
        public void Set(string key, string value, int cacheTimeInSeconds)
        {
            byte[] encoded = Encoding.UTF8.GetBytes(value);
            var options = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(cacheTimeInSeconds)
            };

            _cache.Set(key, encoded, options);
        }

        /// <inheritdoc />
        public void Set<T>(string key, T value) where T : new()
        {
            var serialized = JsonConvert.SerializeObject(value);
            byte[] encoded = Encoding.UTF8.GetBytes(serialized);
            _cache.Set(key, encoded);
        }

        /// <inheritdoc />
        public void Set<T>(string key, T value, int cacheTimeInSeconds)
            where T : new()
        {
            var serialized = JsonConvert.SerializeObject(value);
            byte[] encoded = Encoding.UTF8.GetBytes(serialized);
            var options = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(cacheTimeInSeconds)
            };

            _cache.Set(key, encoded, options);
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <inheritdoc />
        public void Clear()
        {
            var config = _configuration.GetValue<string>(AppSettings.Cache.Configuration);
            var connection = ConnectionMultiplexer.Connect(config);
            var endpoints = connection.GetEndPoints(true);
            foreach (var endpoint in endpoints)
            {
                var server = connection.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }
    }
}