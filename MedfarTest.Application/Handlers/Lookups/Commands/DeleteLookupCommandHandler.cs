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

public class DeleteLookupCommandHandler : IRequestHandler<DeleteLookupRequest, DeleteLookupResponse>
{
    private readonly ILookupRepository _lookupRepository;
    private readonly IMapper _mapper;

    public DeleteLookupCommandHandler(ILookupRepository lookupRepository, IMapper mapper)
    {
        _lookupRepository = lookupRepository;
        _mapper = mapper;
    }

    public async Task<DeleteLookupResponse> Handle(DeleteLookupRequest request, CancellationToken cancellationToken)
    {
        var existing = await _lookupRepository.GetAsync(_ => _.Id == request.Id, cancellationToken);

        if (existing == null)
            throw new ArgumentException("The entity not found");
        
        _lookupRepository.RemoveAndSave(existing);
        return new DeleteLookupResponse(existing.Id);
    }
}