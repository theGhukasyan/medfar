using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Contacts.Requests.Commands;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MedfarTest.Repositories.Contacts;
using MediatR;

namespace MedfarTest.Application.Handlers.Contacts.Commands;

public class CreateContactCommandHandler : IRequestHandler<CreateContactRequest, CreateContactResponse>
{
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;

    public CreateContactCommandHandler(IContactsRepository contactsRepository, IMapper mapper)
    {
        _contactsRepository = contactsRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateContactResponse> Handle(CreateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = _mapper.Map<Contact>(request);
        _contactsRepository.AddAndSave(contact);

        return _mapper.Map<CreateContactResponse>(contact);
    }
}