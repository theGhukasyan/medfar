using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Domain.Users.Requests.Queries;
using MedfarTest.Domain.Users.Responses.Queries;
using MedfarTest.Repositories.Users;
using MediatR;

namespace MedfarTest.Application.Handlers.Users.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserResponse>>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper; 

    public GetAllUsersQueryHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetUserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await _usersRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<GetUserResponse>>(result);
    }
}