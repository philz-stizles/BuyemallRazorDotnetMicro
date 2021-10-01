using StackExchange.Redis;
using System;

namespace BasketService.API.Data
{
    public class BasketDbContext : IBasketDbContext
    {
        private readonly ConnectionMultiplexer _redisConnection;

        public BasketDbContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection ?? throw new ArgumentNullException(nameof(redisConnection));
            Redis = redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
