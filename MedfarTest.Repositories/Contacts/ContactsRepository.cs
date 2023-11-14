using MedfarTest.Data;
using MedfarTest.Data.Entities;
using MedfarTest.Repositories.Common;

namespace MedfarTest.Repositories.Contacts;

public class ContactsRepository : GenericRepository<Contact>, IContactsRepository
{
    public ContactsRepository(MedfarTestDbContext dbContext) : base(dbContext)
    {
    }
}