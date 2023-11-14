using System;
using System.Collections.Generic;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.IndividualMessages.Requests.Queries;

public class GetAllIndividualMessagesQuery : IRequest<IEnumerable<GetIndividualMessageResponse>>
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public string? Body { get; set; }
}