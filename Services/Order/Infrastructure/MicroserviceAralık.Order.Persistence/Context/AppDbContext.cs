using MicroserviceAralık.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Order.Persistence.Context;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=localhost,1481;Initial Catalog=OrderDb;user=sa;password=123456aA.;TrustServerCertificate=true;");
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}
