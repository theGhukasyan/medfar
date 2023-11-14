using MedfarTest.Repositories.Contacts;
using MedfarTest.Repositories.IndividualMessages;
using MedfarTest.Repositories.Lookups;
using MedfarTest.Repositories.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MedfarTest.Api.Extensions;

public static class RepositoriesExtensions
{
    public static void RegisterRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<ILookupRepository, LookupRepository>();
        builder.Services.AddScoped<IIndividualMessagesRepository, IndividualMessagesRepository>();
        builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
    }
}