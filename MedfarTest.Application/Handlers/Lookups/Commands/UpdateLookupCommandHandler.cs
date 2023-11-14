using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Lookups.Requests.Commands;
using MedfarTest.Domain.Lookups.Responses.Commands;
using MedfarTest.Repositories.Lookups;
using MediatR;

namespace MedfarTest.Application.Handlers.Lookups.Commands;

public class UpdateLookupCommandHandler : IRequestHandler<UpdateLookupRequest, UpdateLookupResponse>
{
    private readonly ILookupRepository _lookupRepository;
    private readonly IMapper _mapper;

    public UpdateLookupCommandHandler(ILookupRepository lookupRepository, IMapper mapper)
    {
        _lookupRepository = lookupRepository;
        _mapper = mapper;
    }

    public async Task<UpdateLookupResponse> Handle(UpdateLookupRequest request, CancellationToken cancellationToken)
    {
        var exists = await _lookupRepository.ExistsAsync(lookup => lookup.Id == request.Id, cancellationToken);

        if (!exists)
            throw new ArgumentException("Lookup not found");

        var lookup = _mapper.Map<Lookup>(request);
        _lookupRepository.Update(lookup);

        return _mapper.Map<UpdateLookupResponse>(lookup);
    }
}