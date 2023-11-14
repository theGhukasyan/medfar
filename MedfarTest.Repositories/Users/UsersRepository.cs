using MedfarTest.Data;
using MedfarTest.Data.Entities;
using MedfarTest.Repositories.Common;

namespace MedfarTest.Repositories.Users;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    public UsersRepository(MedfarTestDbContext dbContext) : base(dbContext)
    {
    }
}