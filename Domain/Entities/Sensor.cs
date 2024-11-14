namespace Domain.Entities;

public class Sensor : BaseEntity
{
    public decimal XCoord { get; set; }

    public decimal YCoord { get; set; }

    public string? Description { get; set; }

    public string? ImageFilePath { get; set; }

    public Building Building { get; set; }

    public Guid BuildingId { get; set; }

    public ICollection<SensorData> SensorData { get; set; }

    public User User { get; set; }

    public Guid UserId { get; set; }
}