using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.IndividualMessages.Requests.Commands;
using MedfarTest.Domain.IndividualMessages.Responses.Commands;
using MedfarTest.Repositories.IndividualMessages;
using MediatR;

namespace MedfarTest.Application.Handlers.IndividualMessages.Commands;

public class DeleteIndividualMessageCommandHandler : IRequestHandler<DeleteIndividualMessageRequest, DeleteIndividualMessageResponse>
{
    private readonly IIndividualMessagesRepository _individualMessagesRepository;
    private readonly IMapper _mapper;

    public DeleteIndividualMessageCommandHandler(IIndividualMessagesRepository individualMessagesRepository, IMapper mapper)
    {
        _individualMessagesRepository = individualMessagesRepository;
        _mapper = mapper;
    }

    public async Task<DeleteIndividualMessageResponse> Handle(DeleteIndividualMessageRequest request, CancellationToken cancellationToken)
    {
        var existing = await _individualMessagesRepository.GetAsync(_ => _.Id == request.Id, cancellationToken);

        if (existing == null)
            throw new ArgumentException("The entity not found");
        
        _individualMessagesRepository.RemoveAndSave(existing);
        return new DeleteIndividualMessageResponse(existing.Id);
    }
}