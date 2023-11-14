using System;
using MedfarTest.Domain.Users.Responses.Commands;
using MediatR;

namespace MedfarTest.Domain.Users.Requests.Commands;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public Guid Id { get; set; }

    public DeleteUserRequest(Guid id) => Id = id;
}