using System;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MediatR;

namespace MedfarTest.Domain.Contacts.Requests.Commands;

public class DeleteContactRequest : IRequest<DeleteContactResponse>
{
    public Guid Id { get; set; }

    public DeleteContactRequest(){ }
    
    public DeleteContactRequest(Guid id)
    {
        Id = id;
    }
}