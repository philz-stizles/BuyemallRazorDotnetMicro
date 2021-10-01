using StackExchange.Redis;

namespace BasketService.API.Data
{
    public interface IBasketDbContext
    {
        IDatabase Redis { get; }
    }
}
