using System;

namespace MedfarTest.Domain.Users.Responses.Commands;

public class UpdateUserResponse
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public DateTime DateCreated { get; set; }
}