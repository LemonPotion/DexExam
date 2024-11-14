using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.XCoord)
            .IsRequired();

        builder.Property(s => s.YCoord)
            .IsRequired();

        builder.Property(s => s.Description)
            .HasMaxLength(2000);

        builder.Property(s => s.ImageFilePath);

        builder.HasOne(s => s.Building)
            .WithMany(b => b.Sensors)
            .HasForeignKey(s => s.BuildingId);

        builder.HasOne(s => s.User)
            .WithMany(u => u.Sensors)
            .HasForeignKey(s => s.UserId);

        builder.HasMany(s => s.SensorData)
            .WithOne(sd => sd.Sensor)
            .HasForeignKey(sd => sd.SensorId);
    }
}