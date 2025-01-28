using System;
using System.Collections.Generic;

namespace MemCache
{
    public class CacheKey : IEquatable<CacheKey>
    {
        public string Imsi { get; set; }
        public DateTime StartTime { get; set; }

        public CacheKey(string imsi, DateTime startTime)
        {
            Imsi = imsi;
            StartTime = startTime;
        }

        // Override Equals for key comparison
        public override bool Equals(object obj)
        {
            return Equals(obj as CacheKey);
        }

        public bool Equals(CacheKey other)
        {
            return other != null &&
                   Imsi == other.Imsi &&
                   StartTime == other.StartTime;
        }

        // Override GetHashCode for dictionary key lookup
        public override int GetHashCode()
        {
            unchecked // Allow overflow for hash calculations
            {
                int hash = 17;
                hash = hash * 23 + (Imsi != null ? Imsi.GetHashCode() : 0);
                hash = hash * 23 + StartTime.GetHashCode();
                return hash;
            }
        }


        public override string ToString()
        {
            return $"{Imsi}:{StartTime:yyyy-MM-dd HH:mm:ss}";
        }
    }

    public class InMemoryCache
    {
        // Dictionary to store CacheKey (Imsi, StartTime) as key and PhoneNumber as value
        private Dictionary<CacheKey, string> _cache;

        public InMemoryCache()
        {
            _cache = new Dictionary<CacheKey, string>();
        }

        // Method to add a key-value pair to the cache
        public void Add(string imsi, DateTime startTime, string phoneNumber)
        {
            var key = new CacheKey(imsi, startTime);

            if (!_cache.ContainsKey(key))
            {
                _cache.Add(key, phoneNumber);
                Console.WriteLine($"Added: {key} => {phoneNumber}");
            }
            else
            {
                Console.WriteLine($"Key {key} already exists.");
            }
        }

        // Method to retrieve a value by key from the cache
        public string Get(string imsi, DateTime startTime)
        {
            var key = new CacheKey(imsi, startTime);
            string phoneNumber;
            if (_cache.TryGetValue(key, out phoneNumber))
            {
                return phoneNumber;
            }
            else
            {
                Console.WriteLine($"Key {key} not found.");
                return null;
            }
        }

        // Method to remove a key-value pair from the cache
        public void Remove(string imsi, DateTime startTime)
        {
            var key = new CacheKey(imsi, startTime);

            if (_cache.ContainsKey(key))
            {
                _cache.Remove(key);
                Console.WriteLine($"Removed: {key}");
            }
            else
            {
                Console.WriteLine($"Key {key} not found.");
            }
        }

        // Method to display all key-value pairs in memory
        public void DisplayAll()
        {
            Console.WriteLine("\nCurrent Cache:");
            foreach (var item in _cache)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }

}
