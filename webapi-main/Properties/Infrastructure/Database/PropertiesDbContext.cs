using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class PropertiesDbContext : DbContext
{
    public DbSet<Property> Properties { get; set; }

    public PropertiesDbContext(DbContextOptions<PropertiesDbContext> options) : base(options)
    {
    }
}