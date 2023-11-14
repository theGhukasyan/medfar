using System;

namespace MedfarTest.Domain.Users.Responses.Commands;

public class DeleteUserResponse
{
    public Guid Id { get; set; }
    
    public DeleteUserResponse() {}

    public DeleteUserResponse(Guid id) => Id = id;
}