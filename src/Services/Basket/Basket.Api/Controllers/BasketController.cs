using System;
using System.Net;
using System.Threading.Tasks;
using Basket.Api.Entities;
using Basket.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IDiscountGrpcService _discountGrpcService;

        public BasketController(IBasketService basketService, IDiscountGrpcService discountGrpcService)
        {
            _basketService = basketService ?? throw new ArgumentException(nameof(basketService));
            _discountGrpcService = discountGrpcService ?? throw new ArgumentException(nameof(discountGrpcService));
        }
        
        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _basketService.GetBasketByUserName(userName);

            var res = basket ?? new ShoppingCart(userName);

            return Ok(res);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }
            
            var newBasket = await _basketService.UpdateBasket(basket);

            return Ok(newBasket);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Boolean), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basketService.DeleteBasketByUserName(userName);

            return Ok();
        }

    }
}