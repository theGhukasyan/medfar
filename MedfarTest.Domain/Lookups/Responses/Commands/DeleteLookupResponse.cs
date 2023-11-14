using System;

namespace MedfarTest.Domain.Lookups.Responses.Commands;

public class DeleteLookupResponse
{
    public Guid Id { get; set; }
    
    public DeleteLookupResponse() { }

    public DeleteLookupResponse(Guid id) => Id = id; 
}