using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Xsl;
using AutoMapper;
using MedfarTest.Domain.IndividualMessages.Requests.Queries;
using MedfarTest.Domain.IndividualMessages.Responses.Queries;
using MedfarTest.Repositories.IndividualMessages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedfarTest.Application.Handlers.IndividualMessages.Queries;

public class GetAllIndividualMessageQueryHandler : IRequestHandler<GetAllIndividualMessagesQuery, IEnumerable<GetIndividualMessageResponse>>
{
    private readonly IIndividualMessagesRepository _individualMessagesRepository;
    private readonly IMapper _mapper;
    
    public GetAllIndividualMessageQueryHandler(IIndividualMessagesRepository individualMessagesRepository, IMapper mapper)
    {
        _individualMessagesRepository = individualMessagesRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetIndividualMessageResponse>> Handle(GetAllIndividualMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = _individualMessagesRepository.GetAllAsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Body))
            messages = messages.Where(message => message.Body.Contains(request.Body, StringComparison.OrdinalIgnoreCase));

        if (request.From.HasValue)
            messages = messages.Where(message => message.CreationDate >= request.From);

        if (request.To.HasValue)
            messages = messages.Where(message => message.CreationDate < request.To);

        var result = await messages.ToListAsync(cancellationToken);

        return _mapper.Map<List<GetIndividualMessageResponse>>(result);
    }
}