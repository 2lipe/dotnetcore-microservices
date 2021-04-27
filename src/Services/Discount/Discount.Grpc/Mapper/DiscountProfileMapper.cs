using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfileMapper : Profile
    {
        public DiscountProfileMapper()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}