using MicroserviceAralık.Discount.Context;
using MicroserviceAralık.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Discount.Services.CouponServices;

public class DiscountCouponService(AppDbContext _context) : IDiscountCouponService
{
    public async Task<Coupon> CreateCoupon(Coupon coupon)
    {
        var result = await _context.Coupons.AddAsync(coupon)
;
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteCoupon(int id)
    {
        var coupon = await _context.Coupons.FindAsync(id);
        var result = _context.Coupons.Remove(coupon);
        await _context.SaveChangesAsync();
        return result != null ? true : false;

    }

    public async Task<List<Coupon>> GetAllCoupons()
    {

        return await _context.Coupons.ToListAsync();
    }

    public async Task<Coupon> GetCouponById(int id)
    {

        return await _context.Coupons.FindAsync(id);
    }

    public async Task<Coupon> UpdateCoupon(Coupon coupon)
    {
        var result = _context.Coupons.Update(coupon);
        await _context.SaveChangesAsync();
        return result.Entity;

    }
}
