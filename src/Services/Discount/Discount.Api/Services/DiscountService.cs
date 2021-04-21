using System;
using System.Threading.Tasks;
using Discount.Api.Entities;
using Discount.Api.Repositories;

namespace Discount.Api.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository ?? throw new ArgumentException(nameof(discountRepository));
        }

        public async Task<Coupon> GetProductDiscount(string productName)
        {
            try
            {
                var coupon = await _discountRepository.GetDiscount(productName);
                
                return coupon;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> CreateProductDiscount(Coupon coupon)
        {
            try
            {
                await _discountRepository.CreateDiscount(coupon);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateProductDiscount(Coupon coupon)
        {
            try
            {
                await _discountRepository.UpdateDiscount(coupon);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteProductDiscount(string productName)
        {
            try
            {
                await _discountRepository.DeleteDiscount(productName);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}