using System;
using System.Threading.Tasks;
using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentException(nameof(redisCache));
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            var jsonBasket = JsonConvert.DeserializeObject<ShoppingCart>(basket);

            return jsonBasket;
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            var stringBasket = JsonConvert.SerializeObject(basket);
            await _redisCache.SetStringAsync(basket.UserName, stringBasket);

            var newBasket = await GetBasket(basket.UserName);
            return newBasket;
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}