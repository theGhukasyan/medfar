using System;
using MedfarTest.Domain.Contacts.Responses.Queries;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.Contacts.Requests.Queries;

public class GetContactQuery : IRequest<GetContactResponse>
{
    public Guid Id { get; set; }
    
    public GetContactQuery() {}

    public GetContactQuery(Guid id) => Id = id;
}