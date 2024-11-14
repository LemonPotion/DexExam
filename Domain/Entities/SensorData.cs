namespace Domain.Entities;

public class SensorData : BaseEntity
{
    public int Temperature { get; set; }

    public int Humidity { get; set; }

    public int Charge { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.UtcNow;

    public Sensor Sensor { get; set; }

    public Guid SensorId { get; set; }
}