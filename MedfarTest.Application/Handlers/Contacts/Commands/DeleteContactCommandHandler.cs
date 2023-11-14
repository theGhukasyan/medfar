using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Contacts.Requests.Commands;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MedfarTest.Repositories.Contacts;
using MediatR;

namespace MedfarTest.Application.Handlers.Contacts.Commands;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
{
    private readonly IContactsRepository _contactsRepository;
    private readonly IMapper _mapper;

    public DeleteContactCommandHandler(IContactsRepository contactsRepository, IMapper mapper)
    {
        _contactsRepository = contactsRepository;
        _mapper = mapper;
    }

    public async Task<DeleteContactResponse> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
    {
        var existing = await _contactsRepository.GetAsync(_ => _.Id == request.Id, cancellationToken);

        if (existing == null)
            throw new ArgumentException("The entity not found");
        
        _contactsRepository.RemoveAndSave(existing);
        return new DeleteContactResponse(existing.Id);
    }
}