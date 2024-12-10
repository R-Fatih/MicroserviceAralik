namespace MicroserviceAralık.Discount.Services;

using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using MicroserviceAralık.Discount.Entities;
using MicroserviceAralık.Discount.Protos;
using MicroserviceAralık.Discount.Services.CouponServices;
using CouponService = MicroserviceAralık.Discount.Protos.CouponService;
public class CouponsService(IDiscountCouponService _discountCouponService, IMapper _mapper) : CouponService.CouponServiceBase
{
    public override async Task<Protos.GetCouponResponse> CreateCoupon(Protos.CreateCouponRequest request, ServerCallContext context)
    {

        var coupon = _mapper.Map<Coupon>(request.Coupon);
        var result = await _discountCouponService.CreateCoupon(coupon);
        var mappedValue = _mapper.Map<GetCouponResponse>(result);
        return mappedValue;

    }

    public override async Task<Protos.DeleteCouponResponse> DeleteCoupon(Protos.DeleteCouponRequest request, ServerCallContext context)
    {

        var result = await _discountCouponService.DeleteCoupon(request.Id);
        return new DeleteCouponResponse
        {
            IsDeleted = result
        };
    }

    public override async Task<Protos.GetCouponResponses> GetAllCoupons(Protos.EmptyCoupon request, ServerCallContext context)
    {

        var values = await _discountCouponService.GetAllCoupons();
        var mappedValues = _mapper.Map<List<GetCouponResponse>>(values);
        return new GetCouponResponses
        {
            Coupons = { mappedValues }
        };
    }

    public override async Task<Protos.GetCouponResponse> GetCouponById(Protos.GetCouponByIdRequest request, ServerCallContext context)
    {
        var result = await _discountCouponService.GetCouponById(request.Id);
        var mappedValue = _mapper.Map<GetCouponResponse>(result);
        return mappedValue;

    }

    public override async Task<Protos.GetCouponResponse> UpdateCoupon(Protos.UpdateCouponRequest request, ServerCallContext context)
    {
        var mappedValue = _mapper.Map<Coupon>(request.Coupon);
        var result = await _discountCouponService.UpdateCoupon(mappedValue);
        var mappedResult = _mapper.Map<GetCouponResponse>(result);
        return mappedResult;

    }
}
