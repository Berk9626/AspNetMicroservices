using Basket.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepositories
    {
        Task<ShoppingCard> GetBasket(string userName);
      
        Task<ShoppingCard> UpdateBasket(ShoppingCard basket);
        Task DeleteBasket(string userName);

    }
}
