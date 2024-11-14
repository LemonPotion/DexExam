using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class SensorRepository : BaseRepository<Sensor>
{
    public SensorRepository(ExamContext dbContext) : base(dbContext)
    {
    }
}