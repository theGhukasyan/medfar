using System;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.IndividualMessages.Requests.Queries;

public class GetIndividualMessageQuery : IRequest<GetIndividualMessageResponse>
{
    public Guid Id { get; set; }
    
    public GetIndividualMessageQuery() {}

    public GetIndividualMessageQuery(Guid id) => Id = id;
}