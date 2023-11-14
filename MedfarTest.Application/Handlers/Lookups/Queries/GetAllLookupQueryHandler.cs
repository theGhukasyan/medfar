using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Domain.Lookups.Requests.Queries;
using MedfarTest.Domain.Lookups.Responses.Queries;
using MedfarTest.Repositories.Lookups;
using MediatR;

namespace MedfarTest.Application.Handlers.Lookups.Queries;

public class GetAllLookupQueryHandler : IRequestHandler<GetAllLookupQuery, IEnumerable<GetLookupResponse>>
{
    private readonly ILookupRepository _lookupRepository;
    private readonly IMapper _mapper;
    
    public GetAllLookupQueryHandler(ILookupRepository lookupRepository, IMapper mapper)
    {
        _lookupRepository = lookupRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetLookupResponse>> Handle(GetAllLookupQuery request, CancellationToken cancellationToken)
    {
        var result = await _lookupRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetLookupResponse>>(result);
    }
}