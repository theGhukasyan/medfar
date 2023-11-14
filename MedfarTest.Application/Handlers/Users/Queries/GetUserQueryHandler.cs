using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MedfarTest.Domain.Users.Requests.Queries;
using MedfarTest.Domain.Users.Responses.Queries;
using MedfarTest.Repositories.Users;

namespace MedfarTest.Application.Handlers.Users.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _usersRepository.GetAsync(user => user.Id == request.Id, cancellationToken);
        return _mapper.Map<GetUserResponse>(result);
    }
}