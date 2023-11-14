using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedfarTest.Domain.IndividualMessages.Requests.Commands;
using MedfarTest.Domain.IndividualMessages.Requests.Queries;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedfarTest.Api.Controllers;

public class IndividualMessagesController : BaseApiController
{
    public IndividualMessagesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:guid}")]
    public async Task<GetIndividualMessageResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetIndividualMessageQuery(id), cancellationToken);

    [HttpGet]
    public async Task<IEnumerable<GetIndividualMessageResponse>> GetAllAsync(CancellationToken cancellationToken)
        => await _mediator.Send(new GetAllIndividualMessagesQuery(), cancellationToken);

    [HttpPost]
    public async Task<CreateIndividualMessageResponse> PostAsync(CreateIndividualMessageRequest request, CancellationToken cancellationToken)
        => await _mediator.Send(request, cancellationToken);

    [HttpPut("{id:guid}")]
    public async Task<UpdateIndividualMessageResponse> PutAsync(Guid id, UpdateIndividualMessageRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<DeleteIndividualMessageResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new DeleteIndividualMessageRequest(id), cancellationToken);
}