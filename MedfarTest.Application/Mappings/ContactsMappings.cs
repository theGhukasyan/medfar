using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Contacts.Requests.Commands;
using MedfarTest.Domain.Contacts.Requests.Queries;
using MedfarTest.Domain.Contacts.Responses.Commands;
using MedfarTest.Domain.Contacts.Responses.Queries;

namespace MedfarTest.Application.Mappings;

public class ContactsMappings : Profile
{
    public ContactsMappings()
    {
        CreateMap<Contact, GetContactQuery>();
        CreateMap<CreateContactRequest, Contact>();
        CreateMap<UpdateContactRequest, Contact>();
        CreateMap<Contact, CreateContactResponse>();
        CreateMap<Contact, UpdateContactResponse>();
        CreateMap<Contact, GetContactResponse>();
    }
}