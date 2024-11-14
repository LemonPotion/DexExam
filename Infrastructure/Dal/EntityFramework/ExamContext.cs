using System.Globalization;
using System.Reflection;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework;

public class ExamContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<Building> Buildings => Set<Building>();

    public DbSet<Sensor> Sensors => Set<Sensor>();

    public DbSet<SensorData> SensorsData => Set<SensorData>();

    public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture);
    }
}