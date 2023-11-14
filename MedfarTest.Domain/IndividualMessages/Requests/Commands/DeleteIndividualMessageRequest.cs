using System;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MediatR;

namespace MedfarTest.Domain.IndividualMessages.Requests.Commands;

public class DeleteIndividualMessageRequest : IRequest<DeleteIndividualMessageResponse>
{
    public Guid Id { get; set; }

    public DeleteIndividualMessageRequest(){ }
    
    public DeleteIndividualMessageRequest(Guid id)
    {
        Id = id;
    }
}