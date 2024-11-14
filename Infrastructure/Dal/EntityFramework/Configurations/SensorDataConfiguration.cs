using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;

public class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
{
    public void Configure(EntityTypeBuilder<SensorData> builder)
    {
        builder.HasKey(sd => sd.Id);

        builder.Property(sd => sd.Temperature)
            .IsRequired();

        builder.Property(sd => sd.Humidity)
            .IsRequired();

        builder.Property(sd => sd.Charge)
            .IsRequired();

        builder.Property(sd => sd.CreateDate)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasOne(sd => sd.Sensor)
            .WithMany(s => s.SensorData)
            .HasForeignKey(sd => sd.SensorId);
    }
}