using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Domain.Contacts.Requests.Queries;
using MedfarTest.Domain.Contacts.Responses.Queries;
using MedfarTest.Repositories.Contacts;
using MediatR;

namespace MedfarTest.Application.Handlers.Contacts.Queries;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, GetContactResponse>
{
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;

    public GetContactQueryHandler(IContactsRepository contactsRepository, IMapper mapper)
    {
        _contactsRepository = contactsRepository;
        _mapper = mapper;
    }
    
    public async Task<GetContactResponse> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var message = await _contactsRepository.GetAsync(contact => contact.Id == request.Id, cancellationToken);
        return _mapper.Map<GetContactResponse>(message);
    }
}