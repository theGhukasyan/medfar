using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Contacts.Requests.Commands;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MedfarTest.Repositories.Contacts;
using MediatR;

namespace MedfarTest.Application.Handlers.Contacts.Commands;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactRequest, UpdateContactResponse>
{
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;

    public UpdateContactCommandHandler(IContactsRepository contactsRepository, IMapper mapper)
    {
        _contactsRepository = contactsRepository;
        _mapper = mapper;
    }

    public async Task<UpdateContactResponse> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
    {
        var exists = await _contactsRepository.ExistsAsync(contact => contact.Id == request.Id, cancellationToken);

        if (!exists)
            throw new ArgumentException("Contact not found");

        var contact = _mapper.Map<Contact>(request);
        _contactsRepository.Update(contact);

        return _mapper.Map<UpdateContactResponse>(contact);
    }
}