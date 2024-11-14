using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<Guid>
{
    public ICollection<Building> Buildings { get; set; }

    public ICollection<Sensor> Sensors { get; set; }
}