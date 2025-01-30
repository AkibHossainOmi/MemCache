using System;
using StackExchange.Redis;

namespace MemCache
{
    public class GarnetCache
    {
        private IDatabase _cache;
        private ConnectionMultiplexer _garnet;

        public GarnetCache(string garnetConnectionString)
        {
            _garnet = ConnectionMultiplexer.Connect(garnetConnectionString);
            _cache = _garnet.GetDatabase();
        }

        public void Add(string imsi, DateTime startTime, string phoneNumber)
        {
            var key = new CacheKey(imsi, startTime);
            var garnetKey = key.ToString();

            if (!_cache.KeyExists(garnetKey))
            {
                _cache.StringSet(garnetKey, phoneNumber);
                Console.WriteLine($"Added to Garnet: {garnetKey} => {phoneNumber}");
            }
            else
            {
                Console.WriteLine($"Key {garnetKey} already exists in Garnet.");
            }
        }

        public string Get(string imsi, DateTime startTime)
        {
            var key = new CacheKey(imsi, startTime);
            var garnetKey = key.ToString();

            var phoneNumber = _cache.StringGet(garnetKey);
            if (phoneNumber.HasValue)
            {
                return phoneNumber.ToString();
            }
            else
            {
                Console.WriteLine($"Key {garnetKey} not found in Garnet.");
                return null;
            }
        }

        public void Remove(string imsi, DateTime startTime)
        {
            var key = new CacheKey(imsi, startTime);
            var garnetKey = key.ToString();

            if (_cache.KeyExists(garnetKey))
            {
                _cache.KeyDelete(garnetKey);
                Console.WriteLine($"Removed from Garnet: {garnetKey}");
            }
            else
            {
                Console.WriteLine($"Key {garnetKey} not found in Garnet.");
            }
        }

        public void DisplayAll()
        {
            Console.WriteLine("\nCurrent Garnet Cache:");
            var endpoints = _garnet.GetEndPoints();
            var server = _garnet.GetServer(endpoints[0]);

            foreach (var key in server.Keys(pattern: "*"))
            {
                var value = _cache.StringGet(key);
                Console.WriteLine($"{key} => {value}");
            }
        }
    }
}
