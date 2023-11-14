using System;
using System.Text.Json.Serialization;
using MedfarTest.Domain.Users.Responses.Commands;
using MediatR;

namespace MedfarTest.Domain.Users.Requests.Commands;

public class UpdateUserRequest : IRequest<UpdateUserResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public UpdateUserRequest() { }

    public UpdateUserRequest(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}