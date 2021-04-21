using System.Threading.Tasks;
using Discount.Api.Entities;

namespace Discount.Api.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetProductDiscount(string productName);
        Task<bool> CreateProductDiscount(Coupon coupon);
        Task<bool> UpdateProductDiscount(Coupon coupon);
        Task<bool> DeleteProductDiscount(string productName);
    }
}