namespace Domain.Entities;

public class BuildingUsers : BaseEntity
{
    public Building Building { get; set; }

    public Guid BuildingId { get; set; }

    public User User { get; set; }

    public Guid UserId { get; set; }
}