using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.IndividualMessages.Requests.Commands;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MedfarTest.Repositories.Contacts;
using MedfarTest.Repositories.IndividualMessages;
using MedfarTest.Repositories.Lookups;
using MedfarTest.Repositories.Users;
using MediatR;

namespace MedfarTest.Application.Handlers.IndividualMessages.Commands;

public class UpdateIndividualMessageCommandHandler : IRequestHandler<UpdateIndividualMessageRequest, UpdateIndividualMessageResponse>
{
    private readonly IIndividualMessagesRepository _individualMessagesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly ILookupRepository _lookupRepository;
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;

    public UpdateIndividualMessageCommandHandler(IIndividualMessagesRepository individualMessagesRepository, IMapper mapper, IUsersRepository usersRepository, ILookupRepository lookupRepository, IContactsRepository contactsRepository)
    {
        _individualMessagesRepository = individualMessagesRepository;
        _mapper = mapper;
        _usersRepository = usersRepository;
        _lookupRepository = lookupRepository;
        _contactsRepository = contactsRepository;
    }

    public async Task<UpdateIndividualMessageResponse> Handle(UpdateIndividualMessageRequest request, CancellationToken cancellationToken)
    {
        var exists =
            await _individualMessagesRepository.ExistsAsync(message => message.Id == request.Id, cancellationToken);

        if (!exists)
            throw new ArgumentException("Individual Message not found");

        var userExists = await _usersRepository.ExistsAsync(_ => _.Id == request.CreatedBy, cancellationToken);
        var contactExists = await _contactsRepository.ExistsAsync(_ => _.Id == request.FromContactId, cancellationToken);
        var lookupExists = await _lookupRepository.ExistsAsync(_ => _.Id == request.PriorityLookupId, cancellationToken);
        
        var individualMessage = _mapper.Map<IndividualMessage>(request);
        _individualMessagesRepository.Update(individualMessage);

        return _mapper.Map<UpdateIndividualMessageResponse>(individualMessage);
    }
}