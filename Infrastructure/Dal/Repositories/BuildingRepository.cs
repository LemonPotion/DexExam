using Domain.Entities;
using Infrastructure.Dal.EntityFramework;

namespace Infrastructure.Dal.Repositories;

public class BuildingRepository : BaseRepository<Building>
{
    public BuildingRepository(ExamContext dbContext) : base(dbContext)
    {
    }
}