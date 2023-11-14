using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Users.Requests.Commands;
using MedfarTest.Domain.Users.Responses.Commands;
using MedfarTest.Repositories.Users;
using MediatR;

namespace MedfarTest.Application.Handlers.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        _usersRepository.AddAndSave(user);
        return _mapper.Map<CreateUserResponse>(user);
    }
}