using System;

namespace MedfarTest.Domain.IndividualMessages.Responses.Commands;

public class DeleteIndividualMessageResponse
{
    public Guid Id { get; set; }
    
    public DeleteIndividualMessageResponse() { }

    public DeleteIndividualMessageResponse(Guid id) => Id = id; 
}