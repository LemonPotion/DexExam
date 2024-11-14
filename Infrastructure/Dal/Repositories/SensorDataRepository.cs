using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class SensorDataRepository : BaseRepository<SensorData>
{
    public SensorDataRepository(ExamContext dbContext) : base(dbContext)
    {
    }
}