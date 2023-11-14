using MedfarTest.Data;
using MedfarTest.Data.Entities;
using MedfarTest.Repositories.Common;

namespace MedfarTest.Repositories.Lookups;

public class LookupRepository : GenericRepository<Lookup>, ILookupRepository
{
    public LookupRepository(MedfarTestDbContext dbContext) : base(dbContext)
    {
    }
}