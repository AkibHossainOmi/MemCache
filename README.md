# RedCache - Redis Caching

This project demonstrates how to implement caching in a C# application using Redis as the only caching mechanism. The cache stores and retrieves key-value pairs where the key is a combination of an IMSI (International Mobile Subscriber Identity) and a DateTime representing the start time, and the value is a phone number.

## Requirements

### Software Prerequisites

1. **.NET Framework 4.5.2**
   - You need the .NET SDK installed to compile and run the project.
   - Download from [Microsoft](https://dotnet.microsoft.com/download/dotnet).

2. **Redis Server (Required for RedCache)**
   - You need a running Redis instance for the RedCache functionality. You can either use a local Redis server or a Redis cloud service.
   - Install Redis: [Redis Installation Guide](https://redis.io/download).

3. **Redis Client Library for C# (StackExchange.Redis)**
   - The RedCache class uses the StackExchange.Redis NuGet package. Install it using:

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
     - Add entries to the Redis cache.
     - Retrieve a value using a specified key (IMSI and start time).
     - Remove an entry from the Redis cache.

## Code Explanation

### RedCache Class (Redis-backed Cache)
- **Purpose**: Provides a cache that stores data in a Redis server.
- **Methods**:
  - `Add(string imsi, DateTime startTime, string phoneNumber)`: Adds a new entry to the Redis cache.
  - `Get(string imsi, DateTime startTime)`: Retrieves the phone number from Redis using the given IMSI and start time.
  - `Remove(string imsi, DateTime startTime)`: Removes the entry from the Redis cache.
  - `DisplayAll()`: Displays all entries in Redis (For demonstration, though Redis commands are typically used to fetch data).

### Example Usage
- The `Main` method demonstrates how to use the Redis cache by calling the RedCache methods.

```csharp
class Program
{
    static void Main(string[] args)
    {
        RedCache cache = new RedCache("localhost");

        string imsi = "123456789";
        DateTime startTime = DateTime.Now;
        string phoneNumber = "9876543210";

        // Add entry to cache
        cache.Add(imsi, startTime, phoneNumber);

        // Retrieve entry from cache
        var phone = cache.Get(imsi, startTime);
        Console.WriteLine($"Phone Number: {phone}");

        // Remove entry from cache
        cache.Remove(imsi, startTime);
    }
}
```

## License

This project is open-source and licensed under the MIT License.
