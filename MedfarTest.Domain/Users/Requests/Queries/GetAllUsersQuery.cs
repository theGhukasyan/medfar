using System.Collections.Generic;
using MedfarTest.Domain.Users.Responses.Queries;
using MediatR;

namespace MedfarTest.Domain.Users.Requests.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<GetUserResponse>>
{
    
}