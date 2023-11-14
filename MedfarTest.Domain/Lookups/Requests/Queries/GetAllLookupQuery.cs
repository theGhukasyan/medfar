using System.Collections.Generic;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.Lookups.Requests.Queries;

public class GetAllLookupQuery : IRequest<IEnumerable<GetLookupResponse>>
{
}