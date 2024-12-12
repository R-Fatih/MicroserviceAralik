namespace MicroserviceAralık.Discount.Services;

using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using MicroserviceAralık.Discount.Entities;
using MicroserviceAralık.Discount.Protos;
using MicroserviceAralık.Discount.Services.CouponRedemptionServices;
using Microsoft.AspNetCore.Authorization;
using CouponRedemtionService = MicroserviceAralık.Discount.Protos.CouponRedemptionService;
[Authorize]
public class CouponRedemptionsService(IDiscountCouponRedemptionService _discountCouponRedemptionService, IMapper _mapper) : CouponRedemtionService.CouponRedemptionServiceBase
{
    public override async Task<GetCouponRedemptionResponse> CreateRedemption(CreateRedemptionRequest request, ServerCallContext context)
    {
        var redemption = _mapper.Map<CouponRedemption>(request.Redemption);
        var result = await _discountCouponRedemptionService.CreateCouponRedemption(redemption);
        var mappedValue = _mapper.Map<GetCouponRedemptionResponse>(result);
        return mappedValue;

    }

    public override async Task<DeleteRedemptionResponse> DeleteRedemption(DeleteRedemptionRequest request, ServerCallContext context)
    {
        var result = await _discountCouponRedemptionService.DeleteCouponRedemption(request.Id);
        return new DeleteRedemptionResponse
        {
            IsDeleted = result
        };

    }

    public override async Task<GetCouponRedemptionResponses> GetAllRedemptions(EmptyRedemption request, ServerCallContext context)
    {
        var values = await _discountCouponRedemptionService.GetAllCouponRedemptions();
        var mappedValue = _mapper.Map<List<GetCouponRedemptionResponse>>(values);
        return new GetCouponRedemptionResponses
        {
            Redemptions = { mappedValue }
        };

    }

    public override async Task<GetCouponRedemptionResponse> GetCouponRedemptionById(GetCouponRedemptionByIdRequest request, ServerCallContext context)
    {

        var value = await _discountCouponRedemptionService.GetCouponRedemptionById(request.Id);
        var mappedValue = _mapper.Map<GetCouponRedemptionResponse>(value);
        return mappedValue;
    }

    public override async Task<GetCouponRedemptionResponse> UpdateRedemption(UpdateRedemptionRequest request, ServerCallContext context)
    {
        var mappedValue = _mapper.Map<CouponRedemption>(request.Redemption);
        var value = await _discountCouponRedemptionService.UpdateCouponRedemption(mappedValue);
        var mappedResult = _mapper.Map<GetCouponRedemptionResponse>(value);
        return mappedResult;
    }
}
