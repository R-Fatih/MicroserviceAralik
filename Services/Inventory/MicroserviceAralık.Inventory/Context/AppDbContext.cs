using MicroserviceAralık.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Inventory.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost,1484;initial catalog=InventoryDb;user=sa;password=123456aA.;Trustservercertificate=true;");
    }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
}
