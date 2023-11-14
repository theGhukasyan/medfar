using MedfarTest.Data;
using MedfarTest.Data.Entities;
using MedfarTest.Repositories.Common;

namespace MedfarTest.Repositories.IndividualMessages;

public class IndividualMessagesRepository : GenericRepository<IndividualMessage>, IIndividualMessagesRepository
{
    public IndividualMessagesRepository(MedfarTestDbContext dbContext) : base(dbContext)
    {
    }
}