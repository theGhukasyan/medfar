using System.Collections.Generic;
using MedfarTest.Domain.Contacts.Responses.Queries;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.Contacts.Requests.Queries;

public class GetAllContactQuery : IRequest<IEnumerable<GetContactResponse>>
{
}