using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepositories : IBasketRepositories
    {
        //we gonna perform this interface method inside of the basket repository with using Idistributedcache
        private readonly IDistributedCache _redisCache;

        public BasketRepositories(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCard> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);//returnin basket obj. This basket obj. will be whole Json format
            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ShoppingCard>(basket);
        }

        public async Task<ShoppingCard> UpdateBasket(ShoppingCard basket)
        {
            await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.Username);
        }
    }
}
