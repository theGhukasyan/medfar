using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Users.Requests.Commands;
using MedfarTest.Domain.Users.Requests.Queries;
using MedfarTest.Domain.Users.Responses.Commands;
using MedfarTest.Domain.Users.Responses.Queries;

namespace MedfarTest.Application.Mappings;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, GetUserQuery>();
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
        CreateMap<User, UpdateUserResponse>();
        CreateMap<User, GetUserResponse>();
    }
}