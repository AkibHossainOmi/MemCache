using System;
using StackExchange.Redis;

namespace MemCache
{
    public class RedCache
    {
        private IDatabase _cache;
        private ConnectionMultiplexer _redis;

        public RedCache(string redisConnectionString)
        {
            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _cache = _redis.GetDatabase();
        }

        // Method to add a key-value pair to Redis
        public void Add(string imsi, DateTime startTime, string phoneNumber)
        {
            var key = new CacheKey(imsi, startTime);
            var redisKey = key.ToString(); // Use the string representation of CacheKey as the Redis key

            if (!_cache.KeyExists(redisKey))
            {
                _cache.StringSet(redisKey, phoneNumber);
                Console.WriteLine($"Added to Redis: {redisKey} => {phoneNumber}");
            }
            else
            {
                Console.WriteLine($"Key {redisKey} already exists in Redis.");
            }
        }

        // Method to retrieve a value by key from Redis
        public string Get(string imsi, DateTime startTime)
        {
            var key = new CacheKey(imsi, startTime);
            var redisKey = key.ToString();

            var phoneNumber = _cache.StringGet(redisKey);
            if (phoneNumber.HasValue)
            {
                return phoneNumber.ToString();
            }
            else
            {
                Console.WriteLine($"Key {redisKey} not found in Redis.");
                return null;
            }
        }

        // Method to remove a key-value pair from Redis
        public void Remove(string imsi, DateTime startTime)
        {
            var key = new CacheKey(imsi, startTime);
            var redisKey = key.ToString();

            if (_cache.KeyExists(redisKey))
            {
                _cache.KeyDelete(redisKey);
                Console.WriteLine($"Removed from Redis: {redisKey}");
            }
            else
            {
                Console.WriteLine($"Key {redisKey} not found in Redis.");
            }
        }

        // Method to display all key-value pairs in Redis
        public void DisplayAll()
        {
            Console.WriteLine("\nCurrent Redis Cache:");
            var endpoints = _redis.GetEndPoints();
            var server = _redis.GetServer(endpoints[0]);

            // Get all keys (for small data, this works fine)
            foreach (var key in server.Keys(pattern: "*"))
            {
                var value = _cache.StringGet(key);
                Console.WriteLine($"{key} => {value}");
            }
        }
    }
}
