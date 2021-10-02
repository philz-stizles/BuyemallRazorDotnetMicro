using BasketService.API.Data;
using BasketService.API.Entities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BasketService.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketDbContext _redisDbContext;

        public BasketRepository(IBasketDbContext redisDbContext)
        {
            _redisDbContext = redisDbContext ?? throw new ArgumentNullException(nameof(redisDbContext));
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            return await _redisDbContext.Redis.KeyDeleteAsync(userName);
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = await _redisDbContext.Redis.StringGetAsync(userName);
            if(basket.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basketCart)
        {
            var updatedBasket = await _redisDbContext.Redis
                    .StringSetAsync(basketCart.UserName, JsonConvert.SerializeObject(basketCart));
            if (!updatedBasket)
            {
                return null;
            }

            return await GetBasket(basketCart.UserName);
        }
    }
}
