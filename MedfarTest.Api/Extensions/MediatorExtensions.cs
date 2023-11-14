using System.Collections.Generic;
using System.Reflection;
using MedfarTest.Application.Handlers.Contacts.Commands;
using MedfarTest.Application.Handlers.Contacts.Queries;
using MedfarTest.Application.Handlers.IndividualMessages.Commands;
using MedfarTest.Application.Handlers.IndividualMessages.Queries;
using MedfarTest.Application.Handlers.Lookups.Commands;
using MedfarTest.Application.Handlers.Lookups.Queries;
using MedfarTest.Application.Handlers.Users.Commands;
using MedfarTest.Application.Handlers.Users.Queries;
using MedfarTest.Domain.Contacts.Requests.Commands;
using MedfarTest.Domain.Contacts.Requests.Queries;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MedfarTest.Domain.Contacts.Responses.Queries;
using MedfarTest.Domain.IndividualMessages.Requests.Commands;
using MedfarTest.Domain.IndividualMessages.Requests.Queries;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MedfarTest.Domain.Lookups.Requests.Commands;
using MedfarTest.Domain.Lookups.Requests.Queries;
using MedfarTest.Domain.Lookups.Responses.Commands;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MedfarTest.Domain.Users.Requests.Commands;
using MedfarTest.Domain.Users.Requests.Queries;
using MedfarTest.Domain.Users.Responses.Commands;
using MedfarTest.Domain.Users.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MedfarTest.Api.Extensions;

public static class MediatorExtensions
{
    public static void RegisterMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(_ => _.RegisterServicesFromAssemblies(typeof(Program).Assembly));
        
        builder.Services.AddTransient<IRequestHandler<CreateUserRequest, CreateUserResponse>, CreateUserCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateUserRequest, UpdateUserResponse>, UpdateUserCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteUserRequest, DeleteUserResponse>, DeleteUserCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<GetUserQuery, GetUserResponse>, GetUserQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserResponse>>, GetAllUsersQueryHandler>();
        
        builder.Services.AddTransient<IRequestHandler<CreateLookupRequest, CreateLookupResponse>, CreateLookupCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateLookupRequest, UpdateLookupResponse>, UpdateLookupCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteLookupRequest, DeleteLookupResponse>, DeleteLookupCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<GetLookupQuery, GetLookupResponse>, GetLookupQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllLookupQuery, IEnumerable<GetLookupResponse>>, GetAllLookupQueryHandler>();
        
        builder.Services.AddTransient<IRequestHandler<CreateContactRequest, CreateContactResponse>, CreateContactCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateContactRequest, UpdateContactResponse>, UpdateContactCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteContactRequest, DeleteContactResponse>, DeleteContactCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<GetContactQuery, GetContactResponse>, GetContactQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllContactQuery, IEnumerable<GetContactResponse>>, GetAllContactsQueryHandler>();
        
        builder.Services.AddTransient<IRequestHandler<CreateIndividualMessageRequest, CreateIndividualMessageResponse>, CreateIndividualMessageCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateIndividualMessageRequest, UpdateIndividualMessageResponse>, UpdateIndividualMessageCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteIndividualMessageRequest, DeleteIndividualMessageResponse>, DeleteIndividualMessageCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<GetIndividualMessageQuery, GetIndividualMessageResponse>, GetIndividualMessageQueryHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllIndividualMessagesQuery, IEnumerable<GetIndividualMessageResponse>>, GetAllIndividualMessageQueryHandler>();
    }
}