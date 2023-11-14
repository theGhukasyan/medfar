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

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    
    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetAsync(_ => _.Id == request.Id, cancellationToken);

        if (user == null)
            throw new ArgumentException("User not found");
        
        _usersRepository.RemoveAndSave(user);
        return new DeleteUserResponse(request.Id);
    }
}