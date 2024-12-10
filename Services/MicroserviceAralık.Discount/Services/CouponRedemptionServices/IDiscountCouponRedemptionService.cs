using MicroserviceAralık.Discount.Entities;

namespace MicroserviceAralık.Discount.Services.CouponRedemptionServices;

public interface IDiscountCouponRedemptionService
{
    Task<List<CouponRedemption>> GetAllCouponRedemptions();
    Task<CouponRedemption> GetCouponRedemptionById(int id);
    Task<CouponRedemption> CreateCouponRedemption(CouponRedemption couponRedemption);
    Task<CouponRedemption> UpdateCouponRedemption(CouponRedemption couponRedemption);
    Task<bool> DeleteCouponRedemption(int id);
}
