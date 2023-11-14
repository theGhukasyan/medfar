using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Domain.Contacts.Requests.Queries;
using MedfarTest.Domain.Contacts.Responses.Queries;
using MedfarTest.Repositories.Contacts;
using MedfarTest.Repositories.Lookups;
using MediatR;

namespace MedfarTest.Application.Handlers.Contacts.Queries;

public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactQuery, IEnumerable<GetContactResponse>>
{
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;
    
    public GetAllContactsQueryHandler(IContactsRepository contactsRepository, IMapper mapper)
    {
        _contactsRepository = contactsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetContactResponse>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
    {
        var result = await _contactsRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetContactResponse>>(result);
    }
}