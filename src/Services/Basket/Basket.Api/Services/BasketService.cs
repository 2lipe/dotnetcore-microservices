using System;
using System.Threading.Tasks;
using Basket.Api.Entities;
using Basket.Api.Repositories;

namespace Basket.Api.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<ShoppingCart> GetBasketByUserName(string userName)
        {
            try
            {
                var basket = await _basketRepository.GetBasket(userName);

                return basket;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            try
            {
                var newBasket = await _basketRepository.UpdateBasket(basket);

                return newBasket;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteBasketByUserName(string userName)
        {
            try
            {
                await _basketRepository.DeleteBasket(userName);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}