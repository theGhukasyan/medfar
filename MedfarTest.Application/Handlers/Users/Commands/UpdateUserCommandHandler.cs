using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Users.Requests.Commands;
using MedfarTest.Domain.Users.Responses.Commands;
using MedfarTest.Repositories.Users;
using MediatR;

namespace MedfarTest.Application.Handlers.Users.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var exists = await _usersRepository.ExistsAsync(user => user.Id == request.Id, cancellationToken);

        if (!exists)
            throw new ArgumentException("User is not found");
        
        var user = _mapper.Map<User>(request);
        _usersRepository.Update(user);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}