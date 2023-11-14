using System;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MedfarTest.Domain.Lookups.Responses.Commands;
using MediatR;

namespace MedfarTest.Domain.Lookups.Requests.Commands;

public class DeleteLookupRequest : IRequest<DeleteLookupResponse>
{
    public Guid Id { get; set; }

    public DeleteLookupRequest(){ }
    
    public DeleteLookupRequest(Guid id)
    {
        Id = id;
    }
}