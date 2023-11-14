using System;
using MedfarTest.Domain.Users.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.Users.Requests.Queries;

public class GetUserQuery : IRequest<GetUserResponse>
{
    public Guid Id { get; set; }
    
    public GetUserQuery(){ }

    public GetUserQuery(Guid id)
        => Id = id;
}