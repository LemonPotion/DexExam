using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Address)
            .HasMaxLength(500);

        builder.Property(b => b.Name)
            .HasMaxLength(500);

        builder.Property(b => b.Description)
            .HasMaxLength(2000);


        builder.HasMany(b => b.Sensors)
            .WithOne(s => s.Building)
            .HasForeignKey(s => s.BuildingId);

        builder.HasMany(b => b.Users)
            .WithMany(u => u.Buildings)
            .UsingEntity<BuildingUsers>(
                j => j.HasOne(bu => bu.User).WithMany().HasForeignKey(bu => bu.UserId),
                j => j.HasOne(bu => bu.Building).WithMany().HasForeignKey(bu => bu.BuildingId));
    }
}