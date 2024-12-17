using MicroserviceAralık.Image.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Image.Context;

public class ImageContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;port=3306;database=ImageDb;user=root;password=123456aA.");
    }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<BrandImage> BrandImages { get; set; }
}
