using System;
using System.Net;
using System.Threading.Tasks;
using Discount.Api.Entities;
using Discount.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService ?? throw new ArgumentException(nameof(discountService));
        }
        
        [HttpGet("{productName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetProductDiscount(string productName)
        {
            var res = await _discountService.GetProductDiscount(productName);

            return Ok(res);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateProductDiscount([FromBody] Coupon coupon)
        {
            await _discountService.CreateProductDiscount(coupon);

            var res = CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);

            return res;
        }

        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> UpdateProductDiscount([FromBody] Coupon coupon)
        {
            await _discountService.UpdateProductDiscount(coupon);

            return Ok();
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteProductDiscount(string productName)
        {
            await _discountService.DeleteProductDiscount(productName);

            return Ok();
        }
    }
}