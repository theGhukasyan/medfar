using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Domain.IndividualMessages.Requests.Queries;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MedfarTest.Repositories.IndividualMessages;
using MediatR;

namespace MedfarTest.Application.Handlers.IndividualMessages.Queries;

public class GetIndividualMessageQueryHandler : IRequestHandler<GetIndividualMessageQuery, GetIndividualMessageResponse>
{
    private readonly IIndividualMessagesRepository _individualMessagesRepository;
    private readonly IMapper _mapper;

    public GetIndividualMessageQueryHandler(IIndividualMessagesRepository individualMessagesRepository, IMapper mapper)
    {
        _individualMessagesRepository = individualMessagesRepository;
        _mapper = mapper;
    }

    public async Task<GetIndividualMessageResponse> Handle(GetIndividualMessageQuery request, CancellationToken cancellationToken)
    {
        var message = await _individualMessagesRepository.GetAsync(message => message.Id == request.Id, cancellationToken);
        return _mapper.Map<GetIndividualMessageResponse>(message);
    }
}