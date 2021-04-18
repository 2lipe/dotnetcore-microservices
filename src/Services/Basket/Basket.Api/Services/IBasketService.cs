using System.Threading.Tasks;
using Basket.Api.Entities;

namespace Basket.Api.Services
{
    public interface IBasketService
    {
        Task<ShoppingCart> GetBasketByUserName(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task<bool> DeleteBasketByUserName(string userName);
    }
}