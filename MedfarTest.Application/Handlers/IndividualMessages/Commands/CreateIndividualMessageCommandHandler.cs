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

public class CreateIndividualMessageCommandHandler : IRequestHandler<CreateIndividualMessageRequest, CreateIndividualMessageResponse>
{
    private readonly IIndividualMessagesRepository _individualMessagesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly ILookupRepository _lookupRepository;
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;

    public CreateIndividualMessageCommandHandler(
        IIndividualMessagesRepository individualMessagesRepository, 
        IMapper mapper, 
        IUsersRepository usersRepository, 
        ILookupRepository lookupRepository, 
        IContactsRepository contactsRepository)
    {
        _individualMessagesRepository = individualMessagesRepository;
        _mapper = mapper;
        _usersRepository = usersRepository;
        _lookupRepository = lookupRepository;
        _contactsRepository = contactsRepository;
    }

    public async Task<CreateIndividualMessageResponse> Handle(CreateIndividualMessageRequest request, CancellationToken cancellationToken)
    {
        var individualMessage = _mapper.Map<IndividualMessage>(request);

        var userExists = await _usersRepository.ExistsAsync(_ => _.Id == individualMessage.CreatedBy, cancellationToken);
        var contactExists = await _contactsRepository.ExistsAsync(_ => _.Id == individualMessage.FromContactId, cancellationToken);
        var lookupExists = await _lookupRepository.ExistsAsync(_ => _.Id == individualMessage.PriorityLookupId, cancellationToken);

        if (!userExists) throw new ArgumentException("User not found");
        if (!contactExists) throw new ArgumentException("Contact not found");
        if (!lookupExists) throw new ArgumentException("Priority Lookup not found");

        _individualMessagesRepository.AddAndSave(individualMessage);

        return _mapper.Map<CreateIndividualMessageResponse>(individualMessage);
    }
}