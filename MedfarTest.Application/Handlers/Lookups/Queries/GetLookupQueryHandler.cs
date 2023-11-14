using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Domain.Lookups.Requests.Queries;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MedfarTest.Repositories.Lookups;
using MediatR;

namespace MedfarTest.Application.Handlers.Lookups.Queries;

public class GetLookupQueryHandler : IRequestHandler<GetLookupQuery, GetLookupResponse>
{
    private readonly ILookupRepository _lookupRepository;
    private readonly IMapper _mapper;

    public GetLookupQueryHandler(ILookupRepository lookupRepository, IMapper mapper)
    {
        _lookupRepository = lookupRepository;
        _mapper = mapper;
    }
    
    public async Task<GetLookupResponse> Handle(GetLookupQuery request, CancellationToken cancellationToken)
    {
        var message = await _lookupRepository.GetAsync(lookup => lookup.Id == request.Id, cancellationToken);
        return _mapper.Map<GetLookupResponse>(message);
    }
}