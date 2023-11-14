using System;
using System.Text.Json.Serialization;
using MedfarTest.Domain.Users.Responses.Commands;
using MediatR;


namespace MedfarTest.Domain.Users.Requests.Commands;

public class CreateUserRequest : IRequest<CreateUserResponse>
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    [JsonIgnore]
    public DateTime DateCreated { get; set; }

    public CreateUserRequest()
    {
        DateCreated = DateTime.UtcNow;
    }

    public CreateUserRequest(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateCreated = DateTime.UtcNow;
    }
}