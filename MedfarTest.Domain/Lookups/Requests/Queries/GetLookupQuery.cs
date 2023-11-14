using System;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.Lookups.Requests.Queries;

public class GetLookupQuery : IRequest<GetLookupResponse>
{
    public Guid Id { get; set; }
    
    public GetLookupQuery() { }

    public GetLookupQuery(Guid id) => Id = id;
}