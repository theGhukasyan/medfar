using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedfarTest.Domain.Contacts.Requests.Commands;
using MedfarTest.Domain.Contacts.Requests.Queries;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MedfarTest.Domain.Contacts.Responses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedfarTest.Api.Controllers;

public class ContactsController : BaseApiController
{
    public ContactsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:guid}")]
    public async Task<GetContactResponse> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetContactQuery(id), cancellationToken);

    [HttpGet]
    public async Task<IEnumerable<GetContactResponse>> GetAllAsync(CancellationToken cancellationToken)
        => await _mediator.Send(new GetAllContactQuery(), cancellationToken);

    [HttpPost]
    public async Task<CreateContactResponse> PostAsync(CreateContactRequest request, CancellationToken cancellationToken)
        => await _mediator.Send(request, cancellationToken);

    [HttpPut("{id:guid}")]
    public async Task<UpdateContactResponse> PutAsync(Guid id, UpdateContactRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete("{id:guid}")]
    public async Task<DeleteContactResponse> DeleteAsync(Guid id, CancellationToken cancellationToken)
        => await _mediator.Send(new DeleteContactRequest(id), cancellationToken);
}