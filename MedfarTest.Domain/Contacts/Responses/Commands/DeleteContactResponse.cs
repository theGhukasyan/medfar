using System;

namespace MedfarTest.Domain.Contacts.Responses.Commands;

public class DeleteContactResponse
{
    public Guid Id { get; set; }
    
    public DeleteContactResponse() { }

    public DeleteContactResponse(Guid id) => Id = id; 
}