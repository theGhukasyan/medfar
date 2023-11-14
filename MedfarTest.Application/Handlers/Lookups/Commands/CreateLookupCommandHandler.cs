using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Lookups.Requests.Commands;
using MedfarTest.Domain.Lookups.Responses.Commands;
using MedfarTest.Repositories.Lookups;

namespace MedfarTest.Application.Handlers.Lookups.Commands;

public class CreateLookupCommandHandler : IRequestHandler<CreateLookupRequest, CreateLookupResponse>
{
    private readonly ILookupRepository _lookupRepository;
    private readonly IMapper _mapper;

    public CreateLookupCommandHandler(ILookupRepository lookupRepository, IMapper mapper)
    {
        _lookupRepository = lookupRepository;
        _mapper = mapper;
    }

    public async Task<CreateLookupResponse> Handle(CreateLookupRequest request, CancellationToken cancellationToken)
    {
        var individualMessage = _mapper.Map<Lookup>(request);
        _lookupRepository.AddAndSave(individualMessage);

        return _mapper.Map<CreateLookupResponse>(individualMessage);
    }
}