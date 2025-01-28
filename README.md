# MemCache - InMemory and Redis Caching

This project demonstrates how to implement caching in a C# application using two approaches:

1. **InMemoryCache** - A simple in-memory cache using a `Dictionary` to store key-value pairs.
2. **RedCache** - A Redis-backed cache using the `StackExchange.Redis` library to store and retrieve data.

Both caching mechanisms work with a key composed of an IMSI (International Mobile Subscriber Identity) and a `DateTime` representing the start time, mapping to a phone number.

## Requirements

### Software Prerequisites

1. **.NET Framework 4.5.2**
   - You need the .NET SDK installed to compile and run the project.
   - Download from [Microsoft](https://dotnet.microsoft.com/download/dotnet).

2. **Redis Server (for RedCache)**
   - You need a running Redis instance for the `RedCache` functionality. You can either use a local Redis server or a Redis cloud service.
   - Install Redis: [Redis Installation Guide](https://redis.io/download).

3. **Redis Client Library for C# (StackExchange.Redis)**
   - The `RedCache` class requires the `StackExchange.Redis` NuGet package. Install it using:
     ```bash
     dotnet add package StackExchange.Redis
     ```

## How to Run

1. **Clone or Download the Project**
   - Clone this repository or download the files to your local machine.

2. **Install Redis (for RedCache)** 
   - If using Redis locally, ensure it's running on the default port `6379`. You can do this using:
     ```bash
     redis-server
     ```

3. **Restore Dependencies**
   - In the project folder, restore the NuGet dependencies by running:
     ```bash
     dotnet restore
     ```

4. **Run the Application**
   - You can run the application by executing:
     ```bash
     dotnet run
     ```
   - The program will:
     - Add entries to both the in-memory and Redis cache.
     - Retrieve a value using a specified key.
     - Remove an entry from both caches.
     - Display all cached entries (for in-memory cache only).

## Code Explanation

### `InMemoryCache` Class
- **Purpose**: Provides an in-memory cache that stores key-value pairs using a `Dictionary`.
- **Methods**:
  - `Add(string imsi, DateTime startTime, string phoneNumber)`: Adds a new entry to the cache.
  - `Get(string imsi, DateTime startTime)`: Retrieves the phone number associated with the given IMSI and start time.
  - `Remove(string imsi, DateTime startTime)`: Removes the specified cache entry.
  - `DisplayAll()`: Displays all entries currently in the cache.

### `RedCache` Class (Redis-backed Cache)
- **Purpose**: Provides a cache that stores data in a Redis server.
- **Methods**:
  - `Add(string imsi, DateTime startTime, string phoneNumber)`: Adds a new entry to the Redis cache.
  - `Get(string imsi, DateTime startTime)`: Retrieves the phone number from Redis using the given IMSI and start time.
  - `Remove(string imsi, DateTime startTime)`: Removes the entry from the Redis cache.
  - `DisplayAll()`: Displays all entries (for demonstration, but you would typically use Redis commands for this).

### Example Usage
- The `Main` method demonstrates how to use both caching mechanisms by calling the `InMemoryCache` and `RedCache` methods.

## License

This project is open-source and licensed under the MIT License.