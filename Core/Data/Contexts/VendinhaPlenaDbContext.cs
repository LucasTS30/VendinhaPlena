using Core.Data.EntityConfigs;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Contexts;

public class VendinhaPlenaDbContext : DbContext
{
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Divida> Dividas => Set<Divida>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=Localhost;Database=VendinhaPlena;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteEntityConfig());
        modelBuilder.ApplyConfiguration(new DividaEntityConfig());
    }
}