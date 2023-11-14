using AutoMapper;
using MedfarTest.Data.Entities;
using MedfarTest.Domain.Lookups.Requests.Commands;
using MedfarTest.Domain.Lookups.Requests.Queries;
using MedfarTest.Domain.Lookups.Responses.Commands;
using MedfarTest.Domain.Lookups.Responses.Queries;

namespace MedfarTest.Application.Mappings;

public class LookupMappings : Profile
{
    public LookupMappings()
    {
        CreateMap<Lookup, GetLookupQuery>();
        CreateMap<CreateLookupRequest, Lookup>();
        CreateMap<UpdateLookupRequest, Lookup>();
        CreateMap<Lookup, CreateLookupResponse>();
        CreateMap<Lookup, UpdateLookupResponse>();
        CreateMap<Lookup, GetLookupResponse>();
    }
}