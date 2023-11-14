using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Domain.Lookups.Requests.Commands;
using MedfarTest.Domain.Lookups.Requests.Queries;
using MedfarTest.Domain.Lookups.Responses.Commands;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedfarTest.Api.Controllers;

public class LookupsController : BaseApiController
{
    public LookupsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:guid}")]
    public async Task<GetLookupResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetLookupQuery(id), cancellationToken);

    [HttpGet]
    public async Task<IEnumerable<GetLookupResponse>> GetAllAsync(CancellationToken cancellationToken)
        => await _mediator.Send(new GetAllLookupQuery(), cancellationToken);

    [HttpPost]
    public async Task<CreateLookupResponse> PostAsync(CreateLookupRequest request, CancellationToken cancellationToken)
        => await _mediator.Send(request, cancellationToken);

    [HttpPut("{id:guid}")]
    public async Task<UpdateLookupResponse> PutAsync(Guid id, UpdateLookupRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<DeleteLookupResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new DeleteLookupRequest(id), cancellationToken);
}