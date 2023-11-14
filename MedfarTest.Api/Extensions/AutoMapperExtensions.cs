using AutoMapper;
using MedfarTest.Application.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MedfarTest.Api.Extensions;

public static class AutoMapperExtensions
{
    public static void AddAutoMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMapper>(options =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsersProfile());
                cfg.AddProfile(new LookupMappings());
                cfg.AddProfile(new IndividualMessagesProfile());
                cfg.AddProfile(new ContactsMappings());
            });

            return config.CreateMapper();
        });
    }
}