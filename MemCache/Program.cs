using System;

namespace MemCache
{
    public class Program
    {
        static void Main(string[] args)
        {
            RedCache();
        }
        public static void InMemoryCache()
        {
            var cache = new InMemoryCache();

            // Adding entries to the cache
            cache.Add("470011775763494", DateTime.Parse("2025-01-08 06:04:22"), "8801775763494");
            cache.Add("470011775763495", DateTime.Parse("2025-01-08 06:05:22"), "8801775763495");

            // Retrieving an entry
            string phoneNumber = cache.Get("470011775763494", DateTime.Parse("2025-01-08 06:04:22"));
            Console.WriteLine($"Retrieved Phone Number: {phoneNumber}");

            // Removing an entry
            cache.Remove("470011775763494", DateTime.Parse("2025-01-08 06:04:22"));

            // Display all entries
            cache.DisplayAll();
        }

        public static void RedCache()
        {
            var connectionString = "localhost:6379";

            var cache = new RedCache(connectionString);

            // Adding entries to the cache
            cache.Add("470011775763494", DateTime.Parse("2025-01-08 06:04:22"), "8801775763494");
            cache.Add("470011775763495", DateTime.Parse("2025-01-08 06:05:22"), "8801775763495");

            // Retrieving an entry
            string phoneNumber = cache.Get("470011775763494", DateTime.Parse("2025-01-08 06:04:22"));
            Console.WriteLine($"Retrieved Phone Number: {phoneNumber}");

            // Removing an entry
            cache.Remove("470011775763494", DateTime.Parse("2025-01-08 06:04:22"));

            // Display all entries
            cache.DisplayAll();
        }

    }

}
