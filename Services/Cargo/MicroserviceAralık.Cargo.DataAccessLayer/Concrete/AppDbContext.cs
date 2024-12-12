using MicroserviceAralık.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Cargo.DataAccessLayer.Concrete;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("Server=localhost,1483;Initial Catalog=CargoDb;user=sa;password=123456aA.;TrustServerCertificate=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasMany(x => x.SentCargoDetails).WithOne(x => x.SenderCustomer).HasForeignKey(x => x.SenderCustomerId);
        modelBuilder.Entity<Customer>().HasMany(x => x.ReceivedCargoDetails).WithOne(x => x.ReceiverCustomer).HasForeignKey(x => x.ReceiverCustomerId);

    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Operation> Operations { get; set; }
}
