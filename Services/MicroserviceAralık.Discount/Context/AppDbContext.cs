using MicroserviceAralık.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Discount.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=localhost,1480;Initial Catalog=DiscountDb;user=sa;password=123456aA.;TrustServerCertificate=true;");
    }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<CouponRedemption> CouponRedemptions { get; set; }
}
