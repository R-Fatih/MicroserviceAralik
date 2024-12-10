using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using MicroserviceAralık.Discount.Entities;
using MicroserviceAralık.Discount.Protos;

namespace MicroserviceAralık.Discount.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Coupon, GetCouponResponse>().ReverseMap();
        CreateMap<CouponRedemption, GetCouponRedemptionResponse>().ReverseMap();

        CreateMap<Timestamp, DateTime>().ConvertUsing(t => t == null ? default : t.ToDateTime());
        CreateMap<DateTime, Timestamp>().ConvertUsing(d => Timestamp.FromDateTime(d.ToUniversalTime()));
    }
}
