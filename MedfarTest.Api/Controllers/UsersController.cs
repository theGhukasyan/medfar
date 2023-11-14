using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedfarTest.Domain.Users.Requests.Commands;
using MedfarTest.Domain.Users.Requests.Queries;
using MedfarTest.Domain.Users.Responses.Commands;
using MedfarTest.Domain.Users.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedfarTest.Api.Controllers;

public class UsersController : BaseApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:guid}")]
    public async Task<GetUserResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetUserQuery(id), cancellationToken);

    [HttpGet]
    public async Task<IEnumerable<GetUserResponse>> GetAllAsync(CancellationToken cancellationToken)
        => await _mediator.Send(new GetAllUsersQuery(), cancellationToken);

    [HttpPost]
    public async Task<CreateUserResponse> PostAsync(CreateUserRequest request, CancellationToken cancellationToken)
        => await _mediator.Send(request, cancellationToken);

    [HttpPut("{id:guid}")]
    public async Task<UpdateUserResponse> PutAsync(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<DeleteUserResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new DeleteUserRequest(id), cancellationToken);
}