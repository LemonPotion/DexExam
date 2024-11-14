using Domain.ValueObjects;

namespace Domain.Entities;

public class Building : BaseEntity
{
    public string Address { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Sensor> Sensors { get; set; }

    public ICollection<User> Users { get; set; }
}