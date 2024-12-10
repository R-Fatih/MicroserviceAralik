using MicroserviceAralık.Discount.Context;
using MicroserviceAralık.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Discount.Services.CouponRedemptionServices;

public class DiscountCouponRedemptionService(AppDbContext _context) : IDiscountCouponRedemptionService
{
    public async Task<CouponRedemption> CreateCouponRedemption(CouponRedemption couponRedemption)
    {
        var result = await _context.CouponRedemptions.AddAsync(couponRedemption);
        await _context.SaveChangesAsync();
        return result.Entity;

    }

    public async Task<bool> DeleteCouponRedemption(int id)
    {
        var redemption = await _context.CouponRedemptions.FindAsync(id);
        var result = _context.CouponRedemptions.Remove(redemption);
        await _context.SaveChangesAsync();
        return result != null ? true : false;

    }

    public async Task<List<CouponRedemption>> GetAllCouponRedemptions()
    {
        return await _context.CouponRedemptions.ToListAsync();
    }

    public async Task<CouponRedemption> GetCouponRedemptionById(int id)
    {

        return await _context.CouponRedemptions.FindAsync(id);
    }

    public async Task<CouponRedemption> UpdateCouponRedemption(CouponRedemption couponRedemption)
    {
        var result = _context.CouponRedemptions.Update(couponRedemption);
        await _context.SaveChangesAsync();
        return result.Entity;

    }
}
