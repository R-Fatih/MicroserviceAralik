using MicroserviceAralık.Message.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Message.Dal.Context;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseNpgsql("server=localhost;port=5432;Database=MessageDb;User Id=user;password=123456aA.;");
    }
    public DbSet<UserMessage> UserMessages { get; set; }
}
